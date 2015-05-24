using System.Drawing;
using System.Windows.Forms;

namespace Gardener
{
    /// <summary>
    /// Summary description for GdPic.
    /// </summary>
    public class GdPic : System.Windows.Forms.PictureBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private readonly System.ComponentModel.Container _components = null;

        private Brush _br;
        private Garden _gden;

        private void Init()
        {
            _br = new SolidBrush(Color.LightGray);
        }

        public GdPic()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();
            Init();
        }

        public void SetGarden(Garden garden)
        {
            _gden = garden;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            var g = pe.Graphics;
            g.FillEllipse(_br, 5, 5, 100, 100);
            if (_gden != null)
            {
                _gden.draw(g);
            }
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_components != null)
                {
                    _components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            //
            // GdPic
            //
        }

        #endregion Component Designer generated code
    }
}