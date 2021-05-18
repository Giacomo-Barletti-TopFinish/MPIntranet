﻿using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPIntranet.Common
{
    public partial class MPIBaseForm : Form
    {
        public ContestoBase Contesto;
        private bool _daSalvare = false;
        protected static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public MPIBaseForm()
        {
            try
            {
                InitializeComponent();
                Contesto = ContestoBase.CreaContesto();
            }
            catch (Exception ex)
            {
                MostraEccezione(ex, "Errore in baseform");
            }
        }

        public virtual void MostraEccezione(Exception ex, string messaggioLog)
        {
            ScriviLogErrore(messaggioLog, ex);
            ExceptionFrm frm = new ExceptionFrm(ex);
            frm.ShowDialog();
        }

        protected virtual void MostraEccezione(Exception ex)
        {
            ScriviLogErrore(string.Empty, ex);
            ExceptionFrm frm = new ExceptionFrm(ex);
            frm.ShowDialog();
        }

        protected void ScriviLogInfo(string messaggio)
        {
            Log.Info(messaggio);
        }
        protected void ScriviLogWarning(string messaggio)
        {
            Log.Warn(messaggio);
        }
        protected void ScriviLogErrore(string messaggio)
        {
            Log.Error(messaggio);
        }
        protected void ScriviLogErrore(string messaggio, Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(messaggio);

            while (ex != null)
            {
                sb.AppendLine(ex.Message);
                sb.AppendLine(ex.StackTrace);
                ex = ex.InnerException;
            }
            Log.Error(sb.ToString());
        }

        private void BaseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (_daSalvare)
                {
                    if (DialogResult.Cancel == MessageBox.Show("ATTENZIONE", "Alcune modifiche non sono state salvate. Vuoi procedere con la chiusura della finestra?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
                    {
                        e.Cancel = true;
                    }

                }

                if (this.IsMdiContainer)
                {
                    if (this.MdiChildren.Count() > 0)
                    {
                        foreach (Form f in MdiChildren)
                            f.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MostraEccezione(ex, "Errore in uscita");
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MPIBaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "MPIBaseForm";
            this.ResumeLayout(false);

        }
    }
}
