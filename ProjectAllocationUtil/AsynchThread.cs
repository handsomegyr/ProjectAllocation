using System;
using System.Windows.Forms;

namespace ProjectAllocationUtil
{
	public enum TaskStatus 
	{ 
		Stopped, 
		Aborted,
		ThrowErrorStoped,
		Running, 
		CancelPending,
		AbortPending

	} 

	public class TaskEventArgs : EventArgs 
	{ 
		public Object     Result; 
		public int        Progress;
		public TaskStatus Status; 
		public String Message;
		public TaskEventArgs( int progress ) 
		{ 
			this.Progress = progress; 
			this.Status   = TaskStatus.Running; 
		}
		public TaskEventArgs( TaskStatus status ) 
		{ 
			this.Status = status; 
		}
		public TaskEventArgs( int progress,object result ) 
		{ 
			this.Progress = progress; 
			this.Status   = TaskStatus.Running; 
			this.Result   = result;
		}
		public TaskEventArgs( TaskStatus status,object result ) 
		{ 
			this.Status   = status; 
			this.Result   = result;
		}
		public TaskEventArgs( TaskStatus status,string message ,object result ) 
		{ 
			this.Status   = status; 
			this.Message = message;
			this.Result   = result;
		}
		public TaskEventArgs( int progress,string message ,object result ) 
		{ 
			this.Progress = progress; 
			this.Status   = TaskStatus.Running; 
			this.Message = message;
			this.Result   = result;
		}
		public TaskEventArgs( TaskStatus status,int progress,string message ,object result ) 
		{ 
			this.Status = status;
			this.Progress = progress; 
			this.Message = message;
			this.Result   = result;
		} 
	}     


	public delegate object TaskDelegate( params object[] args ); 

	public delegate void TaskEventHandler( object sender, TaskEventArgs e ); 

	abstract public class Task
	{   
		protected System.Threading.Thread _callThread = null; 

		protected System.Threading.Thread _workThread = null; 

		protected TaskStatus _taskState = TaskStatus.Stopped; 

		protected int _progress = -1;

		protected object _result = null;

		protected Exception _exception = null;

		public event TaskEventHandler TaskStatusChanged; 

		public event TaskEventHandler TaskProgressChanged; 

		public event TaskEventHandler TaskAbort; 

		public event TaskEventHandler TaskThrowError; 

		public event TaskEventHandler TaskCancel; 
		#region 
		

		public Exception Exception
		{
			get { return _exception;}
		}
		
		public System.Threading.Thread CallThread
		{
			get { return _callThread;}
		}
		
		public System.Threading.Thread WordThread
		{
			get {return _workThread;}
		}
		
		
		public int Progress
		{
			get {return _progress;} 
		}
		
		public TaskStatus TaskState
		{
			get {return _taskState;}
		}
		
		public object Result
		{
			get {return _result;}
		}

		protected bool IsStop
		{
			get
			{
				bool result = false;
				switch (_taskState)
				{
					case TaskStatus.Stopped:
					case TaskStatus.Aborted:
					case TaskStatus.ThrowErrorStoped:
						result = true;
						break;
					default:
						break;
				}
				return result;
			}
		}
		#endregion
		#region 

		protected void FireStatusChangedEvent(TaskStatus status, object result) 
		{ 
			if( TaskStatusChanged != null ) 
			{ 
				TaskEventArgs args = new TaskEventArgs( status,result); 
				AsyncInvoke(TaskStatusChanged,args);
			} 
		} 
 
		protected void FireProgressChangedEvent(int progress, object result) 
		{ 
			if( TaskProgressChanged != null ) 
			{ 
				TaskEventArgs args = new TaskEventArgs( progress,result); 
				AsyncInvoke(TaskProgressChanged,args);
			} 
		} 

		protected void FireThrowErrorEvent(int progress, object result) 
		{ 
			if( TaskThrowError != null ) 
			{ 
				TaskEventArgs args = new TaskEventArgs( progress,result); 
				AsyncInvoke(TaskThrowError,args);
			} 
		} 
	
		protected void FireCancelEvent(int progress, object result) 
		{ 
			if( TaskCancel != null ) 
			{ 
				TaskEventArgs args = new TaskEventArgs( progress,result); 
				AsyncInvoke(TaskCancel,args);
			} 
		} 

		protected void FireAbortEvent(int progress, object result) 
		{ 
			if( TaskAbort != null ) 
			{ 
				TaskEventArgs args = new TaskEventArgs( progress,result); 
				AsyncInvoke(TaskAbort,args);
			} 
		} 

		protected void AsyncInvoke(TaskEventHandler eventhandler,TaskEventArgs args)
		{
//			TaskEventHandler[] tpcs = (TaskEventHandler[])eventhandler.GetInvocationList();
			Delegate[] tpcs = eventhandler.GetInvocationList();
			foreach(TaskEventHandler tpc in tpcs)
			{
				if ( tpc.Target is System.Windows.Forms.Control ) 
				{ 
					Control targetForm = tpc.Target as System.Windows.Forms.Control; 
					targetForm.BeginInvoke( tpc,new object[] { this, args } ); 
				} 
				else 
				{ 
					tpc.BeginInvoke(this, args ,null,null); 
				}
			}		
		}
		#endregion
		#region 
		public bool StartTask( params object[] args ) 
		{ 
			return StartTask(new TaskDelegate( Work ),args); 
		} 
		public bool StartTask(TaskDelegate worker ,params object[] args ) 
		{ 
			bool result =false;
			lock( this ) 
			{ 
				if( IsStop && worker != null ) 
				{ 
					_result = null;
					_callThread = System.Threading.Thread.CurrentThread;
					worker.BeginInvoke( args ,new AsyncCallback( EndWorkBack ), worker ); 
					_taskState = TaskStatus.Running; 
					FireStatusChangedEvent( _taskState, null); 
					result = true;
				} 
			} 
			return result;
		} 

		public bool StopTask() 
		{ 
			bool result =false;
			lock( this ) 
			{ 
				if( _taskState == TaskStatus.Running ) 
				{ 
					_taskState = TaskStatus.CancelPending; 
					FireStatusChangedEvent( _taskState, _result); 
					result = true;
				} 
			} 
			return result;
		} 

		public bool AbortTask() 
		{ 
			bool result = false;
			lock( this ) 
			{ 
				if( _taskState == TaskStatus.Running && _workThread != null ) 
				{ 
					if (_workThread.ThreadState != System.Threading.ThreadState.Stopped)
					{
						_workThread.Abort();
					}
					System.Threading.Thread.Sleep(2);
					if (_workThread.ThreadState == System.Threading.ThreadState.Stopped)
					{
						_taskState = TaskStatus.Aborted; 
						result = true;
					}
					else
					{
						_taskState = TaskStatus.AbortPending; 
						result = false;
					}
					FireStatusChangedEvent( _taskState, _result); 
				} 
			} 
			return result;
		} 

		protected void EndWorkBack( IAsyncResult ar ) 
		{ 
			bool error = false;
			bool abort = false;
			try												
			{
				TaskDelegate del = (TaskDelegate)ar.AsyncState; 
				_result = del.EndInvoke( ar ); 
			}
			catch(Exception e)								
			{
				error = true;
				_exception = e;
				if (e.GetType() == typeof(System.Threading.ThreadAbortException))
				{
					abort = true;
					FireAbortEvent(_progress,_exception);
				}
				else
				{
					FireThrowErrorEvent(_progress,_exception);
				}
			}
			lock( this ) 
			{ 
				if (error)
				{
					if ( abort)
					{
						_taskState = TaskStatus.Aborted;		
					}
					else
					{
						_taskState = TaskStatus.ThrowErrorStoped;
					}
				} 
				else
				{	_taskState = TaskStatus.Stopped;}		 
				FireStatusChangedEvent( _taskState, _result);
			} 
		} 
		#endregion

		#region 
		
		virtual public object Work(params  object[] args )
		{
			System.Threading.Thread.CurrentThread.IsBackground = true;
			_workThread = System.Threading.Thread.CurrentThread;
			_result = null;
			return null;
		}

		#endregion
	}
}

#region 

#endregion
