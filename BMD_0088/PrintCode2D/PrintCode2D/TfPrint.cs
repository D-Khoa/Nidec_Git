namespace PrintCode2D
{
    public class TfPrint
    {
        public static string printerName = "SEWOO Label Printer";

        public static void openPrinter()
        {
            long rtn;
            /* 1. LK_OpenPrinter() */
            if (LKBPRINT.LK_OpenPrinter(printerName) != LKBPRINT.LK_SUCCESS)
                throw new System.Exception("Can't open printer!");

            /* 2. LK_SetupPrinter() */
            rtn = LKBPRINT.LK_SetupPrinter("70",   // 10~104 (Unit is mm)
                            "30",       // 5~350 (Unit is mm)
                            0,              // 0=Label with Gap, 1=Label with Black Mark, 2=Label with Continuous.
                            "3",            // if(MediaType==0) <GapHeight> else <BlackMarkHeight>. (Unit is mm)
                            "0",            // if(MediaType==0) <not used> else <distance from BlackMark to perforation>. (Unit is mm)
                            8,              // 0 ~ 15
                            6,              // 2 ~ 6 (Unit is Inch)
                            1               // 1 ~ 9999 copies
                            );

            if (rtn != LKBPRINT.LK_SUCCESS)
            {
                LKBPRINT.LK_ClosePrinter();
                throw new System.Exception("Can't setup printer");
                //return;
            }
        }
        public static void closePrinter()
        {
            /* 4. LK_ClosePrinter() */
            LKBPRINT.LK_ClosePrinter();
        }

        public static void printBitmap(string datecdFile, string QRCode_data)
        {
            long rtn;
            int x, y;
            string printerName = "SEWOO Label Printer";

            /* 1. LK_OpenPrinter() */
            if (LKBPRINT.LK_OpenPrinter(printerName) != LKBPRINT.LK_SUCCESS) { return; }

            /* 2. LK_SetupPrinter() */
            /* 2. LK_SetupPrinter() */
            rtn = LKBPRINT.LK_SetupPrinter("70",   // 10~104 (Unit is mm)
                            "30",       // 5~350 (Unit is mm)
                            0,              // 0=Label with Gap, 1=Label with Black Mark, 2=Label with Continuous.
                            "3",            // if(MediaType==0) <GapHeight> else <BlackMarkHeight>. (Unit is mm)
                            "0",            // if(MediaType==0) <not used> else <distance from BlackMark to perforation>. (Unit is mm)
                            8,              // 0 ~ 15
                            6,              // 2 ~ 6 (Unit is Inch)
                            1               // 1 ~ 9999 copies
                            );

            if (rtn != LKBPRINT.LK_SUCCESS) { LKBPRINT.LK_ClosePrinter(); return; }

            /* 3-1. page 1 test */
            // BARCODE
            x = 8 * 6;
            y = 0 * 6;
            LKBPRINT.LK_StartPage();
            LKBPRINT.LK_PrintBMP(x, y, datecdFile);
            //LINE SN
            x = 26 * 6;
            y = 5 * 8;
            LKBPRINT.LK_PrintDeviceFont(x, y, 0, 3, 1, 1, 0, "SN: ");
            //LINE DATA
            x = 26 * 6;
            y = 8 * 8;
            LKBPRINT.LK_PrintDeviceFont(x, y, 0, 3, 1, 1, 0, QRCode_data);
            LKBPRINT.LK_EndPage();

            /* 4. LK_ClosePrinter() */
            LKBPRINT.LK_ClosePrinter();
        }
    }
}
