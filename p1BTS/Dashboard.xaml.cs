using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace p1BTS
{
    public partial class Dashboard : Window
    {
        private static IntPtr WindowProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            switch (msg)
            {
                case 0x0024:
                    WmGetMinMaxInfo(hwnd, lParam);
                    handled = true;
                    break;
            }
            return (IntPtr)0;
        }

        private static void WmGetMinMaxInfo(IntPtr hwnd, IntPtr lParam)
        {
#pragma warning disable CS8605
            MINMAXINFO mmi = (MINMAXINFO)Marshal.PtrToStructure(lParam, typeof(MINMAXINFO));
#pragma warning restore CS8605
            int MONITOR_DEFAULTTONEAREST = 0x00000002;
            IntPtr monitor = MonitorFromWindow(hwnd, MONITOR_DEFAULTTONEAREST);
            if (monitor != IntPtr.Zero)
            {
                MONITORINFO monitorInfo = new MONITORINFO();
                GetMonitorInfo(monitor, monitorInfo);
                RECT rcWorkArea = monitorInfo.rcWork;
                RECT rcMonitorArea = monitorInfo.rcMonitor;
                mmi.ptMaxPosition.x = Math.Abs(rcWorkArea.left - rcMonitorArea.left);
                mmi.ptMaxPosition.y = Math.Abs(rcWorkArea.top - rcMonitorArea.top);
                mmi.ptMaxSize.x = Math.Abs(rcWorkArea.right - rcWorkArea.left);
                mmi.ptMaxSize.y = Math.Abs(rcWorkArea.bottom - rcWorkArea.top);
            }
            Marshal.StructureToPtr(mmi, lParam, true);
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int x;
            public int y;
            public POINT(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MINMAXINFO
        {
            public POINT ptReserved;
            public POINT ptMaxSize;
            public POINT ptMaxPosition;
            public POINT ptMinTrackSize;
            public POINT ptMaxTrackSize;
        };

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class MONITORINFO
        {
            public int cbSize = Marshal.SizeOf(typeof(MONITORINFO));
            public RECT rcMonitor = new RECT();
            public RECT rcWork = new RECT();
            public int dwFlags = 0;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 0)]
        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
            public static readonly RECT Empty = new RECT();
            public int Width { get { return Math.Abs(right - left); } }
            public int Height { get { return bottom - top; } }
            public RECT(int left, int top, int right, int bottom)
            {
                this.left = left;
                this.top = top;
                this.right = right;
                this.bottom = bottom;
            }
            public RECT(RECT rcSrc)
            {
                left = rcSrc.left;
                top = rcSrc.top;
                right = rcSrc.right;
                bottom = rcSrc.bottom;
            }
            public bool IsEmpty { get { return left >= right || top >= bottom; } }
            public override string ToString()
            {
                if (this == Empty) { return "RECT {Empty}"; }
                return "RECT { left : " + left + " / top : " + top + " / right : " + right + " / bottom : " + bottom + " }";
            }
#pragma warning disable CS8765
            public override bool Equals(object obj)
            {
                if (!(obj is Rect)) { return false; }
                return (this == (RECT)obj);
            }
#pragma warning restore CS8765
            public override int GetHashCode() => left.GetHashCode() + top.GetHashCode() + right.GetHashCode() + bottom.GetHashCode();
            public static bool operator ==(RECT rect1, RECT rect2) { return (rect1.left == rect2.left && rect1.top == rect2.top && rect1.right == rect2.right && rect1.bottom == rect2.bottom); }
            public static bool operator !=(RECT rect1, RECT rect2) { return !(rect1 == rect2); }
        }

        [DllImport("user32")]
        internal static extern bool GetMonitorInfo(IntPtr hMonitor, MONITORINFO lpmi);

        [DllImport("User32")]
        internal static extern IntPtr MonitorFromWindow(IntPtr handle, int flags);
        public Dashboard()
        {
            InitializeComponent();


            ViewModel vm = new ViewModel()
            {
                DataGridItems = new List<DataGridItem>()
                {
                    new DataGridItem() {
                        no = "Ex No 1",
                        so_numb = "Ex SO Numb 1",
                        site_id = "Ex Site ID 1",
                        site_id_op = "Ex Site ID OP 1",
                        site_name = "Ex Site Name 1",
                        company = "Ex Company 1",
                        status = "Ex Status 1",
                        operatr = "Ex Operator 1",
                        tower_height = "Ex Towe Height 1",
                        kom_sitac_date = "Ex KOM Sitac Date 1",
                        project = "Ex Project 1",
                        validasi_date = "Ex Validate Date",
                        long_ = "Ex Long_ 1",
                        lat = "Ex Lat 1",
                        residence = "Ex Residence 1",
                        province = "Ex Province 1",
                        spk_pre_sitac = "Ex SPK Pre Sitac 1",
                        po_pre_sitac = "Ex PO Pre Sitac 1",
                        status_bast = "Ex Status BAST 1",
                        po_sitac = "Ex PO Sitac 1",
                        po_cme = "Ex PO CME",
                        status_bast2 = "Ex Status BAST2 1",
                        po_operasional = "Ex PO Operational 1",
                        po_date = "Ex PO Date 1",
                        status_ = "Ex Status 1",
                        po_comcase = "Ex PO Comcase 1",
                        remark_bast_cme = "Ex Remark BAST CME 1",
                        remark_bast_imb = "Ex Remark BAST IMB",
                    },
                    new DataGridItem() {
                        no = "Ex No 1",
                        so_numb = "Ex SO Numb 1",
                        site_id = "Ex Site ID 1",
                        site_id_op = "Ex Site ID OP 1",
                        site_name = "Ex Site Name 1",
                        company = "Ex Company 1",
                        status = "Ex Status 1",
                        operatr = "Ex Operator 1",
                        tower_height = "Ex Towe Height 1",
                        kom_sitac_date = "Ex KOM Sitac Date 1",
                        project = "Ex Project 1",
                        validasi_date = "Ex Validate Date",
                        long_ = "Ex Long_ 1",
                        lat = "Ex Lat 1",
                        residence = "Ex Residence 1",
                        province = "Ex Province 1",
                        spk_pre_sitac = "Ex SPK Pre Sitac 1",
                        po_pre_sitac = "Ex PO Pre Sitac 1",
                        status_bast = "Ex Status BAST 1",
                        po_sitac = "Ex PO Sitac 1",
                        po_cme = "Ex PO CME",
                        status_bast2 = "Ex Status BAST2 1",
                        po_operasional = "Ex PO Operational 1",
                        po_date = "Ex PO Date 1",
                        status_ = "Ex Status 1",
                        po_comcase = "Ex PO Comcase 1",
                        remark_bast_cme = "Ex Remark BAST CME 1",
                        remark_bast_imb = "Ex Remark BAST IMB",
                    },
                    new DataGridItem() {
                        no = "Ex No 1",
                        so_numb = "Ex SO Numb 1",
                        site_id = "Ex Site ID 1",
                        site_id_op = "Ex Site ID OP 1",
                        site_name = "Ex Site Name 1",
                        company = "Ex Company 1",
                        status = "Ex Status 1",
                        operatr = "Ex Operator 1",
                        tower_height = "Ex Towe Height 1",
                        kom_sitac_date = "Ex KOM Sitac Date 1",
                        project = "Ex Project 1",
                        validasi_date = "Ex Validate Date",
                        long_ = "Ex Long_ 1",
                        lat = "Ex Lat 1",
                        residence = "Ex Residence 1",
                        province = "Ex Province 1",
                        spk_pre_sitac = "Ex SPK Pre Sitac 1",
                        po_pre_sitac = "Ex PO Pre Sitac 1",
                        status_bast = "Ex Status BAST 1",
                        po_sitac = "Ex PO Sitac 1",
                        po_cme = "Ex PO CME",
                        status_bast2 = "Ex Status BAST2 1",
                        po_operasional = "Ex PO Operational 1",
                        po_date = "Ex PO Date 1",
                        status_ = "Ex Status 1",
                        po_comcase = "Ex PO Comcase 1",
                        remark_bast_cme = "Ex Remark BAST CME 1",
                        remark_bast_imb = "Ex Remark BAST IMB",
                    },
                    new DataGridItem() {
                        no = "Ex No 1",
                        so_numb = "Ex SO Numb 1",
                        site_id = "Ex Site ID 1",
                        site_id_op = "Ex Site ID OP 1",
                        site_name = "Ex Site Name 1",
                        company = "Ex Company 1",
                        status = "Ex Status 1",
                        operatr = "Ex Operator 1",
                        tower_height = "Ex Towe Height 1",
                        kom_sitac_date = "Ex KOM Sitac Date 1",
                        project = "Ex Project 1",
                        validasi_date = "Ex Validate Date",
                        long_ = "Ex Long_ 1",
                        lat = "Ex Lat 1",
                        residence = "Ex Residence 1",
                        province = "Ex Province 1",
                        spk_pre_sitac = "Ex SPK Pre Sitac 1",
                        po_pre_sitac = "Ex PO Pre Sitac 1",
                        status_bast = "Ex Status BAST 1",
                        po_sitac = "Ex PO Sitac 1",
                        po_cme = "Ex PO CME",
                        status_bast2 = "Ex Status BAST2 1",
                        po_operasional = "Ex PO Operational 1",
                        po_date = "Ex PO Date 1",
                        status_ = "Ex Status 1",
                        po_comcase = "Ex PO Comcase 1",
                        remark_bast_cme = "Ex Remark BAST CME 1",
                        remark_bast_imb = "Ex Remark BAST IMB",
                    },
                    new DataGridItem() {
                        no = "Ex No 1",
                        so_numb = "Ex SO Numb 1",
                        site_id = "Ex Site ID 1",
                        site_id_op = "Ex Site ID OP 1",
                        site_name = "Ex Site Name 1",
                        company = "Ex Company 1",
                        status = "Ex Status 1",
                        operatr = "Ex Operator 1",
                        tower_height = "Ex Towe Height 1",
                        kom_sitac_date = "Ex KOM Sitac Date 1",
                        project = "Ex Project 1",
                        validasi_date = "Ex Validate Date",
                        long_ = "Ex Long_ 1",
                        lat = "Ex Lat 1",
                        residence = "Ex Residence 1",
                        province = "Ex Province 1",
                        spk_pre_sitac = "Ex SPK Pre Sitac 1",
                        po_pre_sitac = "Ex PO Pre Sitac 1",
                        status_bast = "Ex Status BAST 1",
                        po_sitac = "Ex PO Sitac 1",
                        po_cme = "Ex PO CME",
                        status_bast2 = "Ex Status BAST2 1",
                        po_operasional = "Ex PO Operational 1",
                        po_date = "Ex PO Date 1",
                        status_ = "Ex Status 1",
                        po_comcase = "Ex PO Comcase 1",
                        remark_bast_cme = "Ex Remark BAST CME 1",
                        remark_bast_imb = "Ex Remark BAST IMB",
                    },
                    new DataGridItem() {
                        no = "Ex No 1",
                        so_numb = "Ex SO Numb 1",
                        site_id = "Ex Site ID 1",
                        site_id_op = "Ex Site ID OP 1",
                        site_name = "Ex Site Name 1",
                        company = "Ex Company 1",
                        status = "Ex Status 1",
                        operatr = "Ex Operator 1",
                        tower_height = "Ex Towe Height 1",
                        kom_sitac_date = "Ex KOM Sitac Date 1",
                        project = "Ex Project 1",
                        validasi_date = "Ex Validate Date",
                        long_ = "Ex Long_ 1",
                        lat = "Ex Lat 1",
                        residence = "Ex Residence 1",
                        province = "Ex Province 1",
                        spk_pre_sitac = "Ex SPK Pre Sitac 1",
                        po_pre_sitac = "Ex PO Pre Sitac 1",
                        status_bast = "Ex Status BAST 1",
                        po_sitac = "Ex PO Sitac 1",
                        po_cme = "Ex PO CME",
                        status_bast2 = "Ex Status BAST2 1",
                        po_operasional = "Ex PO Operational 1",
                        po_date = "Ex PO Date 1",
                        status_ = "Ex Status 1",
                        po_comcase = "Ex PO Comcase 1",
                        remark_bast_cme = "Ex Remark BAST CME 1",
                        remark_bast_imb = "Ex Remark BAST IMB",
                    },
                    new DataGridItem() {
                        no = "Ex No 1",
                        so_numb = "Ex SO Numb 1",
                        site_id = "Ex Site ID 1",
                        site_id_op = "Ex Site ID OP 1",
                        site_name = "Ex Site Name 1",
                        company = "Ex Company 1",
                        status = "Ex Status 1",
                        operatr = "Ex Operator 1",
                        tower_height = "Ex Towe Height 1",
                        kom_sitac_date = "Ex KOM Sitac Date 1",
                        project = "Ex Project 1",
                        validasi_date = "Ex Validate Date",
                        long_ = "Ex Long_ 1",
                        lat = "Ex Lat 1",
                        residence = "Ex Residence 1",
                        province = "Ex Province 1",
                        spk_pre_sitac = "Ex SPK Pre Sitac 1",
                        po_pre_sitac = "Ex PO Pre Sitac 1",
                        status_bast = "Ex Status BAST 1",
                        po_sitac = "Ex PO Sitac 1",
                        po_cme = "Ex PO CME",
                        status_bast2 = "Ex Status BAST2 1",
                        po_operasional = "Ex PO Operational 1",
                        po_date = "Ex PO Date 1",
                        status_ = "Ex Status 1",
                        po_comcase = "Ex PO Comcase 1",
                        remark_bast_cme = "Ex Remark BAST CME 1",
                        remark_bast_imb = "Ex Remark BAST IMB",
                    },
                    new DataGridItem() {
                        no = "Ex No 1",
                        so_numb = "Ex SO Numb 1",
                        site_id = "Ex Site ID 1",
                        site_id_op = "Ex Site ID OP 1",
                        site_name = "Ex Site Name 1",
                        company = "Ex Company 1",
                        status = "Ex Status 1",
                        operatr = "Ex Operator 1",
                        tower_height = "Ex Towe Height 1",
                        kom_sitac_date = "Ex KOM Sitac Date 1",
                        project = "Ex Project 1",
                        validasi_date = "Ex Validate Date",
                        long_ = "Ex Long_ 1",
                        lat = "Ex Lat 1",
                        residence = "Ex Residence 1",
                        province = "Ex Province 1",
                        spk_pre_sitac = "Ex SPK Pre Sitac 1",
                        po_pre_sitac = "Ex PO Pre Sitac 1",
                        status_bast = "Ex Status BAST 1",
                        po_sitac = "Ex PO Sitac 1",
                        po_cme = "Ex PO CME",
                        status_bast2 = "Ex Status BAST2 1",
                        po_operasional = "Ex PO Operational 1",
                        po_date = "Ex PO Date 1",
                        status_ = "Ex Status 1",
                        po_comcase = "Ex PO Comcase 1",
                        remark_bast_cme = "Ex Remark BAST CME 1",
                        remark_bast_imb = "Ex Remark BAST IMB",
                    },
                    new DataGridItem() {
                        no = "Ex No 1",
                        so_numb = "Ex SO Numb 1",
                        site_id = "Ex Site ID 1",
                        site_id_op = "Ex Site ID OP 1",
                        site_name = "Ex Site Name 1",
                        company = "Ex Company 1",
                        status = "Ex Status 1",
                        operatr = "Ex Operator 1",
                        tower_height = "Ex Towe Height 1",
                        kom_sitac_date = "Ex KOM Sitac Date 1",
                        project = "Ex Project 1",
                        validasi_date = "Ex Validate Date",
                        long_ = "Ex Long_ 1",
                        lat = "Ex Lat 1",
                        residence = "Ex Residence 1",
                        province = "Ex Province 1",
                        spk_pre_sitac = "Ex SPK Pre Sitac 1",
                        po_pre_sitac = "Ex PO Pre Sitac 1",
                        status_bast = "Ex Status BAST 1",
                        po_sitac = "Ex PO Sitac 1",
                        po_cme = "Ex PO CME",
                        status_bast2 = "Ex Status BAST2 1",
                        po_operasional = "Ex PO Operational 1",
                        po_date = "Ex PO Date 1",
                        status_ = "Ex Status 1",
                        po_comcase = "Ex PO Comcase 1",
                        remark_bast_cme = "Ex Remark BAST CME 1",
                        remark_bast_imb = "Ex Remark BAST IMB",
                    },
                    new DataGridItem() {
                        no = "Ex No 1",
                        so_numb = "Ex SO Numb 1",
                        site_id = "Ex Site ID 1",
                        site_id_op = "Ex Site ID OP 1",
                        site_name = "Ex Site Name 1",
                        company = "Ex Company 1",
                        status = "Ex Status 1",
                        operatr = "Ex Operator 1",
                        tower_height = "Ex Towe Height 1",
                        kom_sitac_date = "Ex KOM Sitac Date 1",
                        project = "Ex Project 1",
                        validasi_date = "Ex Validate Date",
                        long_ = "Ex Long_ 1",
                        lat = "Ex Lat 1",
                        residence = "Ex Residence 1",
                        province = "Ex Province 1",
                        spk_pre_sitac = "Ex SPK Pre Sitac 1",
                        po_pre_sitac = "Ex PO Pre Sitac 1",
                        status_bast = "Ex Status BAST 1",
                        po_sitac = "Ex PO Sitac 1",
                        po_cme = "Ex PO CME",
                        status_bast2 = "Ex Status BAST2 1",
                        po_operasional = "Ex PO Operational 1",
                        po_date = "Ex PO Date 1",
                        status_ = "Ex Status 1",
                        po_comcase = "Ex PO Comcase 1",
                        remark_bast_cme = "Ex Remark BAST CME 1",
                        remark_bast_imb = "Ex Remark BAST IMB",
                    },
                    new DataGridItem() {
                        no = "Ex No 1",
                        so_numb = "Ex SO Numb 1",
                        site_id = "Ex Site ID 1",
                        site_id_op = "Ex Site ID OP 1",
                        site_name = "Ex Site Name 1",
                        company = "Ex Company 1",
                        status = "Ex Status 1",
                        operatr = "Ex Operator 1",
                        tower_height = "Ex Towe Height 1",
                        kom_sitac_date = "Ex KOM Sitac Date 1",
                        project = "Ex Project 1",
                        validasi_date = "Ex Validate Date",
                        long_ = "Ex Long_ 1",
                        lat = "Ex Lat 1",
                        residence = "Ex Residence 1",
                        province = "Ex Province 1",
                        spk_pre_sitac = "Ex SPK Pre Sitac 1",
                        po_pre_sitac = "Ex PO Pre Sitac 1",
                        status_bast = "Ex Status BAST 1",
                        po_sitac = "Ex PO Sitac 1",
                        po_cme = "Ex PO CME",
                        status_bast2 = "Ex Status BAST2 1",
                        po_operasional = "Ex PO Operational 1",
                        po_date = "Ex PO Date 1",
                        status_ = "Ex Status 1",
                        po_comcase = "Ex PO Comcase 1",
                        remark_bast_cme = "Ex Remark BAST CME 1",
                        remark_bast_imb = "Ex Remark BAST IMB",
                    },
                    new DataGridItem() {
                        no = "Ex No 1",
                        so_numb = "Ex SO Numb 1",
                        site_id = "Ex Site ID 1",
                        site_id_op = "Ex Site ID OP 1",
                        site_name = "Ex Site Name 1",
                        company = "Ex Company 1",
                        status = "Ex Status 1",
                        operatr = "Ex Operator 1",
                        tower_height = "Ex Towe Height 1",
                        kom_sitac_date = "Ex KOM Sitac Date 1",
                        project = "Ex Project 1",
                        validasi_date = "Ex Validate Date",
                        long_ = "Ex Long_ 1",
                        lat = "Ex Lat 1",
                        residence = "Ex Residence 1",
                        province = "Ex Province 1",
                        spk_pre_sitac = "Ex SPK Pre Sitac 1",
                        po_pre_sitac = "Ex PO Pre Sitac 1",
                        status_bast = "Ex Status BAST 1",
                        po_sitac = "Ex PO Sitac 1",
                        po_cme = "Ex PO CME",
                        status_bast2 = "Ex Status BAST2 1",
                        po_operasional = "Ex PO Operational 1",
                        po_date = "Ex PO Date 1",
                        status_ = "Ex Status 1",
                        po_comcase = "Ex PO Comcase 1",
                        remark_bast_cme = "Ex Remark BAST CME 1",
                        remark_bast_imb = "Ex Remark BAST IMB",
                    },
                    new DataGridItem() {
                        no = "Ex No 1",
                        so_numb = "Ex SO Numb 1",
                        site_id = "Ex Site ID 1",
                        site_id_op = "Ex Site ID OP 1",
                        site_name = "Ex Site Name 1",
                        company = "Ex Company 1",
                        status = "Ex Status 1",
                        operatr = "Ex Operator 1",
                        tower_height = "Ex Towe Height 1",
                        kom_sitac_date = "Ex KOM Sitac Date 1",
                        project = "Ex Project 1",
                        validasi_date = "Ex Validate Date",
                        long_ = "Ex Long_ 1",
                        lat = "Ex Lat 1",
                        residence = "Ex Residence 1",
                        province = "Ex Province 1",
                        spk_pre_sitac = "Ex SPK Pre Sitac 1",
                        po_pre_sitac = "Ex PO Pre Sitac 1",
                        status_bast = "Ex Status BAST 1",
                        po_sitac = "Ex PO Sitac 1",
                        po_cme = "Ex PO CME",
                        status_bast2 = "Ex Status BAST2 1",
                        po_operasional = "Ex PO Operational 1",
                        po_date = "Ex PO Date 1",
                        status_ = "Ex Status 1",
                        po_comcase = "Ex PO Comcase 1",
                        remark_bast_cme = "Ex Remark BAST CME 1",
                        remark_bast_imb = "Ex Remark BAST IMB",
                    },
                    new DataGridItem() {
                        no = "Ex No 1",
                        so_numb = "Ex SO Numb 1",
                        site_id = "Ex Site ID 1",
                        site_id_op = "Ex Site ID OP 1",
                        site_name = "Ex Site Name 1",
                        company = "Ex Company 1",
                        status = "Ex Status 1",
                        operatr = "Ex Operator 1",
                        tower_height = "Ex Towe Height 1",
                        kom_sitac_date = "Ex KOM Sitac Date 1",
                        project = "Ex Project 1",
                        validasi_date = "Ex Validate Date",
                        long_ = "Ex Long_ 1",
                        lat = "Ex Lat 1",
                        residence = "Ex Residence 1",
                        province = "Ex Province 1",
                        spk_pre_sitac = "Ex SPK Pre Sitac 1",
                        po_pre_sitac = "Ex PO Pre Sitac 1",
                        status_bast = "Ex Status BAST 1",
                        po_sitac = "Ex PO Sitac 1",
                        po_cme = "Ex PO CME",
                        status_bast2 = "Ex Status BAST2 1",
                        po_operasional = "Ex PO Operational 1",
                        po_date = "Ex PO Date 1",
                        status_ = "Ex Status 1",
                        po_comcase = "Ex PO Comcase 1",
                        remark_bast_cme = "Ex Remark BAST CME 1",
                        remark_bast_imb = "Ex Remark BAST IMB",
                    },
                    new DataGridItem() {
                        no = "Ex No 1",
                        so_numb = "Ex SO Numb 1",
                        site_id = "Ex Site ID 1",
                        site_id_op = "Ex Site ID OP 1",
                        site_name = "Ex Site Name 1",
                        company = "Ex Company 1",
                        status = "Ex Status 1",
                        operatr = "Ex Operator 1",
                        tower_height = "Ex Towe Height 1",
                        kom_sitac_date = "Ex KOM Sitac Date 1",
                        project = "Ex Project 1",
                        validasi_date = "Ex Validate Date",
                        long_ = "Ex Long_ 1",
                        lat = "Ex Lat 1",
                        residence = "Ex Residence 1",
                        province = "Ex Province 1",
                        spk_pre_sitac = "Ex SPK Pre Sitac 1",
                        po_pre_sitac = "Ex PO Pre Sitac 1",
                        status_bast = "Ex Status BAST 1",
                        po_sitac = "Ex PO Sitac 1",
                        po_cme = "Ex PO CME",
                        status_bast2 = "Ex Status BAST2 1",
                        po_operasional = "Ex PO Operational 1",
                        po_date = "Ex PO Date 1",
                        status_ = "Ex Status 1",
                        po_comcase = "Ex PO Comcase 1",
                        remark_bast_cme = "Ex Remark BAST CME 1",
                        remark_bast_imb = "Ex Remark BAST IMB",
                    },
                    new DataGridItem() {
                        no = "Ex No 1",
                        so_numb = "Ex SO Numb 1",
                        site_id = "Ex Site ID 1",
                        site_id_op = "Ex Site ID OP 1",
                        site_name = "Ex Site Name 1",
                        company = "Ex Company 1",
                        status = "Ex Status 1",
                        operatr = "Ex Operator 1",
                        tower_height = "Ex Towe Height 1",
                        kom_sitac_date = "Ex KOM Sitac Date 1",
                        project = "Ex Project 1",
                        validasi_date = "Ex Validate Date",
                        long_ = "Ex Long_ 1",
                        lat = "Ex Lat 1",
                        residence = "Ex Residence 1",
                        province = "Ex Province 1",
                        spk_pre_sitac = "Ex SPK Pre Sitac 1",
                        po_pre_sitac = "Ex PO Pre Sitac 1",
                        status_bast = "Ex Status BAST 1",
                        po_sitac = "Ex PO Sitac 1",
                        po_cme = "Ex PO CME",
                        status_bast2 = "Ex Status BAST2 1",
                        po_operasional = "Ex PO Operational 1",
                        po_date = "Ex PO Date 1",
                        status_ = "Ex Status 1",
                        po_comcase = "Ex PO Comcase 1",
                        remark_bast_cme = "Ex Remark BAST CME 1",
                        remark_bast_imb = "Ex Remark BAST IMB",
                    },
                    new DataGridItem() {
                        no = "Ex No 1",
                        so_numb = "Ex SO Numb 1",
                        site_id = "Ex Site ID 1",
                        site_id_op = "Ex Site ID OP 1",
                        site_name = "Ex Site Name 1",
                        company = "Ex Company 1",
                        status = "Ex Status 1",
                        operatr = "Ex Operator 1",
                        tower_height = "Ex Towe Height 1",
                        kom_sitac_date = "Ex KOM Sitac Date 1",
                        project = "Ex Project 1",
                        validasi_date = "Ex Validate Date",
                        long_ = "Ex Long_ 1",
                        lat = "Ex Lat 1",
                        residence = "Ex Residence 1",
                        province = "Ex Province 1",
                        spk_pre_sitac = "Ex SPK Pre Sitac 1",
                        po_pre_sitac = "Ex PO Pre Sitac 1",
                        status_bast = "Ex Status BAST 1",
                        po_sitac = "Ex PO Sitac 1",
                        po_cme = "Ex PO CME",
                        status_bast2 = "Ex Status BAST2 1",
                        po_operasional = "Ex PO Operational 1",
                        po_date = "Ex PO Date 1",
                        status_ = "Ex Status 1",
                        po_comcase = "Ex PO Comcase 1",
                        remark_bast_cme = "Ex Remark BAST CME 1",
                        remark_bast_imb = "Ex Remark BAST IMB",
                    },
                    new DataGridItem() {
                        no = "Ex No 1",
                        so_numb = "Ex SO Numb 1",
                        site_id = "Ex Site ID 1",
                        site_id_op = "Ex Site ID OP 1",
                        site_name = "Ex Site Name 1",
                        company = "Ex Company 1",
                        status = "Ex Status 1",
                        operatr = "Ex Operator 1",
                        tower_height = "Ex Towe Height 1",
                        kom_sitac_date = "Ex KOM Sitac Date 1",
                        project = "Ex Project 1",
                        validasi_date = "Ex Validate Date",
                        long_ = "Ex Long_ 1",
                        lat = "Ex Lat 1",
                        residence = "Ex Residence 1",
                        province = "Ex Province 1",
                        spk_pre_sitac = "Ex SPK Pre Sitac 1",
                        po_pre_sitac = "Ex PO Pre Sitac 1",
                        status_bast = "Ex Status BAST 1",
                        po_sitac = "Ex PO Sitac 1",
                        po_cme = "Ex PO CME",
                        status_bast2 = "Ex Status BAST2 1",
                        po_operasional = "Ex PO Operational 1",
                        po_date = "Ex PO Date 1",
                        status_ = "Ex Status 1",
                        po_comcase = "Ex PO Comcase 1",
                        remark_bast_cme = "Ex Remark BAST CME 1",
                        remark_bast_imb = "Ex Remark BAST IMB",
                    },
                    new DataGridItem() {
                        no = "Ex No 1",
                        so_numb = "Ex SO Numb 1",
                        site_id = "Ex Site ID 1",
                        site_id_op = "Ex Site ID OP 1",
                        site_name = "Ex Site Name 1",
                        company = "Ex Company 1",
                        status = "Ex Status 1",
                        operatr = "Ex Operator 1",
                        tower_height = "Ex Towe Height 1",
                        kom_sitac_date = "Ex KOM Sitac Date 1",
                        project = "Ex Project 1",
                        validasi_date = "Ex Validate Date",
                        long_ = "Ex Long_ 1",
                        lat = "Ex Lat 1",
                        residence = "Ex Residence 1",
                        province = "Ex Province 1",
                        spk_pre_sitac = "Ex SPK Pre Sitac 1",
                        po_pre_sitac = "Ex PO Pre Sitac 1",
                        status_bast = "Ex Status BAST 1",
                        po_sitac = "Ex PO Sitac 1",
                        po_cme = "Ex PO CME",
                        status_bast2 = "Ex Status BAST2 1",
                        po_operasional = "Ex PO Operational 1",
                        po_date = "Ex PO Date 1",
                        status_ = "Ex Status 1",
                        po_comcase = "Ex PO Comcase 1",
                        remark_bast_cme = "Ex Remark BAST CME 1",
                        remark_bast_imb = "Ex Remark BAST IMB",
                    },
                    new DataGridItem() {
                        no = "Ex No 1",
                        so_numb = "Ex SO Numb 1",
                        site_id = "Ex Site ID 1",
                        site_id_op = "Ex Site ID OP 1",
                        site_name = "Ex Site Name 1",
                        company = "Ex Company 1",
                        status = "Ex Status 1",
                        operatr = "Ex Operator 1",
                        tower_height = "Ex Towe Height 1",
                        kom_sitac_date = "Ex KOM Sitac Date 1",
                        project = "Ex Project 1",
                        validasi_date = "Ex Validate Date",
                        long_ = "Ex Long_ 1",
                        lat = "Ex Lat 1",
                        residence = "Ex Residence 1",
                        province = "Ex Province 1",
                        spk_pre_sitac = "Ex SPK Pre Sitac 1",
                        po_pre_sitac = "Ex PO Pre Sitac 1",
                        status_bast = "Ex Status BAST 1",
                        po_sitac = "Ex PO Sitac 1",
                        po_cme = "Ex PO CME",
                        status_bast2 = "Ex Status BAST2 1",
                        po_operasional = "Ex PO Operational 1",
                        po_date = "Ex PO Date 1",
                        status_ = "Ex Status 1",
                        po_comcase = "Ex PO Comcase 1",
                        remark_bast_cme = "Ex Remark BAST CME 1",
                        remark_bast_imb = "Ex Remark BAST IMB",
                    },
                    new DataGridItem() {
                        no = "Ex No 1",
                        so_numb = "Ex SO Numb 1",
                        site_id = "Ex Site ID 1",
                        site_id_op = "Ex Site ID OP 1",
                        site_name = "Ex Site Name 1",
                        company = "Ex Company 1",
                        status = "Ex Status 1",
                        operatr = "Ex Operator 1",
                        tower_height = "Ex Towe Height 1",
                        kom_sitac_date = "Ex KOM Sitac Date 1",
                        project = "Ex Project 1",
                        validasi_date = "Ex Validate Date",
                        long_ = "Ex Long_ 1",
                        lat = "Ex Lat 1",
                        residence = "Ex Residence 1",
                        province = "Ex Province 1",
                        spk_pre_sitac = "Ex SPK Pre Sitac 1",
                        po_pre_sitac = "Ex PO Pre Sitac 1",
                        status_bast = "Ex Status BAST 1",
                        po_sitac = "Ex PO Sitac 1",
                        po_cme = "Ex PO CME",
                        status_bast2 = "Ex Status BAST2 1",
                        po_operasional = "Ex PO Operational 1",
                        po_date = "Ex PO Date 1",
                        status_ = "Ex Status 1",
                        po_comcase = "Ex PO Comcase 1",
                        remark_bast_cme = "Ex Remark BAST CME 1",
                        remark_bast_imb = "Ex Remark BAST IMB",
                    },
                    new DataGridItem() {
                        no = "Ex No 1",
                        so_numb = "Ex SO Numb 1",
                        site_id = "Ex Site ID 1",
                        site_id_op = "Ex Site ID OP 1",
                        site_name = "Ex Site Name 1",
                        company = "Ex Company 1",
                        status = "Ex Status 1",
                        operatr = "Ex Operator 1",
                        tower_height = "Ex Towe Height 1",
                        kom_sitac_date = "Ex KOM Sitac Date 1",
                        project = "Ex Project 1",
                        validasi_date = "Ex Validate Date",
                        long_ = "Ex Long_ 1",
                        lat = "Ex Lat 1",
                        residence = "Ex Residence 1",
                        province = "Ex Province 1",
                        spk_pre_sitac = "Ex SPK Pre Sitac 1",
                        po_pre_sitac = "Ex PO Pre Sitac 1",
                        status_bast = "Ex Status BAST 1",
                        po_sitac = "Ex PO Sitac 1",
                        po_cme = "Ex PO CME",
                        status_bast2 = "Ex Status BAST2 1",
                        po_operasional = "Ex PO Operational 1",
                        po_date = "Ex PO Date 1",
                        status_ = "Ex Status 1",
                        po_comcase = "Ex PO Comcase 1",
                        remark_bast_cme = "Ex Remark BAST CME 1",
                        remark_bast_imb = "Ex Remark BAST IMB",
                    },
                    new DataGridItem() {
                        no = "Ex No 1",
                        so_numb = "Ex SO Numb 1",
                        site_id = "Ex Site ID 1",
                        site_id_op = "Ex Site ID OP 1",
                        site_name = "Ex Site Name 1",
                        company = "Ex Company 1",
                        status = "Ex Status 1",
                        operatr = "Ex Operator 1",
                        tower_height = "Ex Towe Height 1",
                        kom_sitac_date = "Ex KOM Sitac Date 1",
                        project = "Ex Project 1",
                        validasi_date = "Ex Validate Date",
                        long_ = "Ex Long_ 1",
                        lat = "Ex Lat 1",
                        residence = "Ex Residence 1",
                        province = "Ex Province 1",
                        spk_pre_sitac = "Ex SPK Pre Sitac 1",
                        po_pre_sitac = "Ex PO Pre Sitac 1",
                        status_bast = "Ex Status BAST 1",
                        po_sitac = "Ex PO Sitac 1",
                        po_cme = "Ex PO CME",
                        status_bast2 = "Ex Status BAST2 1",
                        po_operasional = "Ex PO Operational 1",
                        po_date = "Ex PO Date 1",
                        status_ = "Ex Status 1",
                        po_comcase = "Ex PO Comcase 1",
                        remark_bast_cme = "Ex Remark BAST CME 1",
                        remark_bast_imb = "Ex Remark BAST IMB",
                    },
                    new DataGridItem() {
                        no = "Ex No 1",
                        so_numb = "Ex SO Numb 1",
                        site_id = "Ex Site ID 1",
                        site_id_op = "Ex Site ID OP 1",
                        site_name = "Ex Site Name 1",
                        company = "Ex Company 1",
                        status = "Ex Status 1",
                        operatr = "Ex Operator 1",
                        tower_height = "Ex Towe Height 1",
                        kom_sitac_date = "Ex KOM Sitac Date 1",
                        project = "Ex Project 1",
                        validasi_date = "Ex Validate Date",
                        long_ = "Ex Long_ 1",
                        lat = "Ex Lat 1",
                        residence = "Ex Residence 1",
                        province = "Ex Province 1",
                        spk_pre_sitac = "Ex SPK Pre Sitac 1",
                        po_pre_sitac = "Ex PO Pre Sitac 1",
                        status_bast = "Ex Status BAST 1",
                        po_sitac = "Ex PO Sitac 1",
                        po_cme = "Ex PO CME",
                        status_bast2 = "Ex Status BAST2 1",
                        po_operasional = "Ex PO Operational 1",
                        po_date = "Ex PO Date 1",
                        status_ = "Ex Status 1",
                        po_comcase = "Ex PO Comcase 1",
                        remark_bast_cme = "Ex Remark BAST CME 1",
                        remark_bast_imb = "Ex Remark BAST IMB",
                    }
                }
            };

            this.DataContext = vm;

            SourceInitialized += (s, e) =>
            {
                IntPtr handler = (new WindowInteropHelper(this)).Handle;
                HwndSource.FromHwnd(handler).AddHook(new HwndSourceHook(WindowProc));
            };
            this.sv.Height = this.Height - 110;
            this.sv.Width = this.dddt.Width;
            MaxHeight = SystemParameters.VirtualScreenHeight;
            MinimizeWindowBtn.Click += (s, e) => WindowState = WindowState.Minimized;
            MaximizeWindowBtn.Click += (s, e) => WindowState = (WindowState == WindowState.Maximized) ? WindowState.Normal : WindowState.Maximized;
            CloseAppBtn.Click += (s, e) => Application.Current.Shutdown();

        }


        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.sv.Height = this.Height - 110;
            this.sv.Width = this.dddt.Width;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void sv_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }
    }
}
