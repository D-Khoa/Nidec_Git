namespace SoftPrintLabel.Model
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

        public static void printBarCodeNew(string Asset_No, string Asset_Name, string Model, string Ser, string Inv)
        {
            //itemNo = "A32-164D-X";
            //itemName = "SHAFT";
            //supplier = "SHINDENSHA CO.,LTD.";
            //invoice = "NDCV160129";
            //date = "2017/12/31";
            //qty = "2500";
            //validity = string.Empty; //"2017/12/31";

            int x, y;
            int cell = 6;
            //string printerName = "SEWOO Label Printer";

            int xdots, model; // ydots;
            string TwoBAR_Command;
            string QRCode_data = Asset_No + "," + Asset_Name + "," + Model + "," + Ser + "," + Inv;

            /* 3-1. page 1 test */
            LKBPRINT.LK_StartPage();

            // QR Code のプリントアウト
            // bx,y,Q,1,z,L,"DATA"
            // x = x position.
            // y = y position
            // z = Cell Size. (2 ~ 16)
            // L = ECC Level(L or M or Q or H)
            x = 6 * cell; //80
            y = 14 * cell; //32
            xdots = 2; //3
            model = 1;
            TwoBAR_Command = string.Format("b{0},{1},Q,{2},{3},L,\"{4}\"\r\n", x, y, model, xdots, QRCode_data);
            LKBPRINT.LK_DirectCommand(TwoBAR_Command);


            //LINE 1 - S3
            x = 20 * cell;
            y = 6 * cell;//Y=4
            LKBPRINT.LK_PrintDeviceFont(x, y, 0, 3, 1, 1, 0, Asset_No);

            //LINE 2 - S4

            x = 20 * cell;
            y = 11 * cell; //Y=8
            LKBPRINT.LK_PrintDeviceFont(x, y, 0, 3, 1, 1, 0, "Name: " + Asset_Name);
            //LINE 3 - S2
            x = 20 * cell;
            y = 16 * cell;//Y=13
            LKBPRINT.LK_PrintDeviceFont(x, y, 0, 3, 1, 1, 0, "Model: " + Model);

            //LINE 4 - S4
            x = 20 * cell;
            y = 21 * cell;//Y=17
            LKBPRINT.LK_PrintDeviceFont(x, y, 0, 3, 1, 1, 0, "Ser: " + Ser);

            //LINE 5 - S2


            x = 20 * cell;
            y = 26 * cell;//Y=22
            LKBPRINT.LK_PrintDeviceFont(x, y, 0, 3, 1, 1, 0, "Inv: " + Inv);


            LKBPRINT.LK_EndPage();
        }
    }
}
