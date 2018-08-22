using System;
using System.Windows.Forms;
using ProjectAllocation.Command;
using ProjectAllocationFramework.Command;
using ProjectAllocationUtil;
using ProjectAllocationFramework;
using ProjectAllocationBusiness;
using System.Drawing;

namespace ProjectAllocation
{
    public partial class frmLogin : frmSmallBase
    {        
        public frmLogin()
        {
            InitializeComponent();
            this.Icon = ProjectAllocationResource.Resource.ProjectAllocationLogin;
            this.Font = Constant.ProjectAllocationFont;
            this.panel1.BackgroundImage = ProjectAllocationResource.Resource.nikon2;
            this.panel1.Height = this.panel1.BackgroundImage.Height;
            this.Width = this.panel1.BackgroundImage.Width;
            this.txtUser.Text = "U0001";// string.Empty;
            this.txtPwd.Text = "1";//string.Empty;

            ChangeStatus();

        }

        private void ChangeStatus()
        {
            btnOK.Enabled = true;// ConfigUtil.IsSetted();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (string.IsNullOrEmpty(this.txtUser.Text.Trim()))
                {
                    MessageUtil.ErrorMessage(ProjectAllocationResource.Message.Login_UserID_NoInput_Info, this.Text);
                    return;
                }

                if (string.IsNullOrEmpty(this.txtPwd.Text.Trim()))
                {
                    MessageUtil.ErrorMessage(ProjectAllocationResource.Message.Login_UserPwd_NoInput_Info, this.Text);
                    return;
                }

                CommandBase command = CommandManager.GetCommand(typeof(LoginCommand));
                bool loginSucess = (bool)command.Execute(this.txtUser.Text.Trim(), this.txtPwd.Text.Trim());

                if (loginSucess)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageUtil.ErrorMessage(ProjectAllocationResource.Message.Login_UserPwd_Error, this.Text);
                }

            }
            catch
            {
                throw;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }


        
    }
}
