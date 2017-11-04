using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace printing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DialogResult aResult;

        private void button1_Click(object sender, EventArgs e)
        {

            aResult = printDialog1.ShowDialog();
            if (aResult == DialogResult.OK)
                printDialog1.Document.Print();
        }





        private void button2_Click(object sender, EventArgs e)
        {
            pageSetupDialog1.Document = printDocument1;
            pageSetupDialog1.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }



        public void PrintEllipse(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        { e.Graphics.DrawEllipse(Pens.Black, e.MarginBounds); }

        // This method must handle the PrintPage event 
        public void PrintGraphics(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath myPath = new System.Drawing.Drawing2D.GraphicsPath();
            myPath.AddPolygon(new Point[] { new Point(1, 1), new Point(12, 55), new Point(34, 8), new Point(52, 53), new Point(99, 5) });
            myPath.AddRectangle(new Rectangle(33, 43, 20, 20));
            e.Graphics.DrawPath(Pens.Black, myPath);
        }




        // These two variables are used to keep track of which page is printing
        int x; int y; // This method must handle the PrintPages event.
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(richTextBox1.Text, new Font("ARIAL", 100), Brushes.Blue, 100, 30);
            // Draws the Ellipse at different origination points, which has the
            // effect of sending successive page-sized pieces of the ellipse to the 
            // printer based on the value of x and y 
            e.Graphics.FillEllipse(Brushes.Blue, new RectangleF(-e.PageBounds.Width * x, -e.PageBounds.Height * y, e.PageBounds.Width * 2, e.PageBounds.Height * 6));
       
        y += 1; 
            if (y == 6 & x == 0) 
            { y = 0; x ++; e.HasMorePages = true; } 
                else if (y == 6 & x == 1)
                       { // The print job is finished 
                            e.HasMorePages = false; } 
                                 else { // Fires the print event again 
                                        e.HasMorePages = true; }
        
        
        }
        // Assumes an image called myImage. This method must handle the PrintPages 
        //event 
        private void PrintDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Image img = Image.FromFile("D:\\foto.jpg");
            e.Graphics.DrawImage(img, new PointF(0, 0));
            
            Font myFont = new Font("Tahoma", 12, FontStyle.Regular, GraphicsUnit.Pixel); string Hello = "Hello World!";
            e.Graphics.DrawString(Hello, myFont, Brushes.AliceBlue, 100, 100);
        }
        private void button4_Click(object sender, EventArgs e)
        {

            printPreviewDialog2.Document = printDocument2;
            printPreviewDialog2.ShowDialog();
        }

       
        
       /* private void PrintStrings(object sender, System.Drawing.Printing.PrintPageEventArgs e) {
            Font myFont = new Font("Tahoma", 12, FontStyle.Regular, GraphicsUnit.Pixel);
            
            int[] myStrings =new int [10] ;
            int ArrayCounter = 0;
          
            
            // Declares the variables that will be used to keep track of spacing and paging 
            float LeftMargin = e.MarginBounds.Left; 
            float TopMargin = e.MarginBounds.Top; 
            float MyLines = 0; 
           float YPosition = 0; 
           int Counter = 0; 
           string CurrentLine; 
            //Calculate the number of lines per
            MyLines = e.MarginBounds.Height;
          //  myFont.GetHeight(e.Graphics);
            // Prints each line of the array, but stops at the end of a page
           // while (Counter < MyLines && ArrayCounter <= myStrings.Length -1)
            //{int ArrayCounter = 0;
               // CurrentLine = myStrings[ArrayCounter];
           /* YPosition = TopMargin + Counter * myFont.GetHeight(e.Graphics);
            e.Graphics.DrawString(CurrentLine, myFont, Brushes.Black, LeftMargin, YPosition, new StringFormat());
            Counter ++;
            ArrayCounter++; } 
             If more lines exist, print another page
            if (!(ArrayCounter == myStrings.GetLength(0) -1)) 
            e.HasMorePages = true;
                  else e.HasMorePages = false;**/

              




























































       

        private void button5_Click(object sender, EventArgs e)
        {
            printPreviewDialog2.Document = printDocument2;
            printPreviewDialog2.ShowDialog();

        }

        private void printDocument3_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        
                MessageBox.Show("Your print job is complete");
    
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            printPreviewDialog2.Document = printDocument3;
            printPreviewDialog2.ShowDialog();
        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            textBox1.DoDragDrop(textBox1.Text, DragDropEffects.Copy);
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }

        }

        private void textBox2_DragDrop(object sender, DragEventArgs e)
        {
            textBox2.Text = (string)e.Data.GetData(DataFormats.Text);
        }

        private void c(object sender, EventArgs e)
        {

        }

        private void treeView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            treeView1.DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void treeView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void treeView1_DragDrop(object sender, DragEventArgs e)
        {
            TreeNode anode;
            if(e.Data.GetDataPresent("System.Windows.Forms.TreeNode",false))
            {
                Point ap;
                TreeNode trgetnode;
                ap=treeView1.PointToClient(new Point(e.X,e.Y));
                trgetnode=((TreeView)sender).GetNodeAt(ap);
                anode=(TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
                trgetnode.Nodes.Add((TreeNode)anode.Clone());
                trgetnode.Expand();
                anode.Remove();
            }}

        }
}

