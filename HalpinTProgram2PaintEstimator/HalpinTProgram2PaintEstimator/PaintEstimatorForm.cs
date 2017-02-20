
/// CIS 207 Program 2: Paint Estimator Program - Winter 2017 
/// Taressa Halpin Date: February 2017 
/// 
/// 


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HalpinTProgram2PaintEstimator
{
    public partial class PaintEstimatorForm : Form
    {
        //DECLARATION OF ALL VARIABLES 

        //INPUTS
        private bool validationBoolean = false;
        //  private int roomDimensionInteger = 0; 
        private int lengthInteger = 0;
        private int widthInteger = 0;
        private int heightInteger = 0;

        //CALCULATED FIELDS 
        private int totalRoomLengthInteger = 0;
        private int totalRoomWidthInteger = 0;
        private int roomToPaintAreaInteger = 0;
        private int numberOfGallonsToPaintInteger = 0;
        private decimal numberOfHoursOfLaborDecimal = 0;
        private decimal costOfLaborDecimal = 0;
        private decimal costOfPaintDecimal = 0;
        private decimal totalCostOfRoomDecimal = 0;
        private decimal fractionOfHoursDecimal = 0;

        //ASSIGNED FIELDS 

        /*ACCUMULATORS FOR EACH HOUSE*/


        /*CONSTANT FIELDS: */
        private const int COVERAGE_PER_GALLON_INTEGER = 115;
        private const decimal LABOR_COST_PER_HOUR_DECIMAL = 35m;

        /*Paint Quality Constants*/
        private const decimal FAIR_PAINT_QUALITY_COST_DECIMAL = 19.95m;
        private const decimal REGULAR_PAINT_QUALITY_COST_DECIMAL = 24.95m;
        private const decimal BETTER_PAINT_QUALITY_COST_DECIMAL = 30.00m;
        private const decimal BEST_PAINT_QUALITY_COST_DECIMAL = 34.50m;

        /*Service Constants*/
        private const decimal SERVICE_COSTS_EXTRAS_DECIMAL = 20.00m; 



         /*BOOLEAN AND CONTROL VARIABLES*/

         /*DAILY TOTALS FOR THE COMPANY*/

        


        /*EVENT HANDLER FOR FORM OBJECT*/
        private void PaintEstimatorForm_Load(object sender, EventArgs e)
        {

        }
        
        public PaintEstimatorForm()
        { InitializeComponent(); }

        private void inputValidation()
            {
                paintQualityGroupBox.BackColor = Color.Azure;
                supplyServiceGroupBox.BackColor = Color.Azure;

                if (nameTextBox.Text.Trim() != string.Empty)
                {
                    if (phoneMaskedTextBox.MaskCompleted)
                    {
                        if (streetAddressTextBox.Text.Trim() != string.Empty)
                        {
                            if (cityAddressTextBox.Text.Trim() != string.Empty)
                            {
                                if (lengthTextBox.Text.Trim() != string.Empty)
                                {
                                    try
                                    {
                                        lengthInteger = int.Parse(lengthTextBox.Text);
                                        if (lengthInteger > 0)
                                        {
                                            if (widthTextBox.Text.Trim() != string.Empty)
                                            {
                                                try
                                                {
                                                    widthInteger = int.Parse(widthTextBox.Text);
                                                    if (widthInteger > 0)
                                                    {
                                                        if (heightTextBox.Text.Trim() != string.Empty)
                                                        {
                                                            try
                                                            {
                                                                heightInteger = int.Parse(heightTextBox.Text);
                                                                if (heightInteger > 0)
                                                                {
                                                                    if (firstRadioButton.Checked || secondRadioButton.Checked ||
                                                                        thirdRadioButton.Checked || fourthRadioButton.Checked)

                                                                    {
                                                                        validationBoolean = true;
                                                                    }

                                                                    else
                                                                    {
                                                                        MessageBox.Show("Select a Paint Quality!", "PAINT QUALITY INPUT ERROR!",
                                                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                                        paintQualityGroupBox.BackColor = Color.Azure;
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    MessageBox.Show("Height of Room: Enter a Positive Integer", "INTEGER INPUT ERROR",
                                                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                                } 
                                                            } 
                                                            catch
                                                            {
                                                                MessageBox.Show("Height of Room: Enter a Number Not a Text!", "NUMBER INPUT ERROR",
                                                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                            }
                                                    
                                                        }
                                                                                                    
                                                  
                                                        else
                                                        {
                                                            MessageBox.Show("Enter Height of Room!", "ROOM HEIGHT INPUT ERROR",
                                                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                        }
                                                    }

                                                    else
                                                    {
                                                        MessageBox.Show("Enter Width of Room!", "ROOM WIDTH INPUT ERROR",
                                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    }

                                                }
                                                catch
                                                {
                                                    MessageBox.Show("Width of Room: Enter a Number Not a Text!","NUMBER INPUT ERROR",
                                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                }
                                            }  
                                            else
                                            {
                                                MessageBox.Show("Width of Room: Enter a Positive Integer","INTEGER INPUT ERROR",
                                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            } 
                                        } 
                                        else
                                        {
                                            MessageBox.Show("Length of Room: Enter a Positive Integer!", "INTEGER INPUT ERROR",
                                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }

                                    }
                                    catch
                                    {
                                        MessageBox.Show("Length of Room: Enter a Number Not a Text!", "NUMBER INPUT ERROR", 
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }  
                                else
                                {
                                    MessageBox.Show("Enter Length of Room!", "ROOM LENGTH INPUT ERROR",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Enter your city address!", "CITY ADDRESS INPUT ERROR",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Enter your street address!", "STREET ADDRESS INPUT ERROR",
                                MessageBoxButtons.OK, MessageBoxIcon.Information); 
                        }
                    } 
                    else
                    {
                        MessageBox.Show("Please Enter Your Phone Number. (Masked Text Box)", "PHONE INPUT ERROR!",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter Your Full Name.", "NAME INPUT ERROR",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } 


      
        /*EVENT HANDLER FOR PROCESS ROOM BUTTON*/
        private void processRoomButton_Click(object sender, EventArgs e)
        {
            inputValidation();
            if (validationBoolean == true)
            {
                calculateDataOneRoom(); 
            }  
                   

        }

      private void calculateDataOneRoom()
        {
            totalRoomLengthInteger = (lengthInteger * heightInteger * 2);
            totalRoomWidthInteger = (widthInteger * heightInteger * 2);
            roomToPaintAreaInteger = (int)((totalRoomLengthInteger + totalRoomWidthInteger) * .8);
            numberOfGallonsToPaintInteger = roomToPaintAreaInteger / 115;

            if ((roomToPaintAreaInteger / 115) != 0)
            {
                numberOfGallonsToPaintInteger++;
            }
            numberOfHoursOfLaborDecimal = roomToPaintAreaInteger / 115 * 3;
            fractionOfHoursDecimal = numberOfHoursOfLaborDecimal -
                                     Math.Truncate(numberOfHoursOfLaborDecimal);
            if (fractionOfHoursDecimal > .75m)
            {
                numberOfHoursOfLaborDecimal = Math.Truncate(numberOfHoursOfLaborDecimal + 1); 
            }
            else
            {
                if (fractionOfHoursDecimal > .25m)
                {
                    numberOfHoursOfLaborDecimal = Math.Truncate(numberOfHoursOfLaborDecimal) + .5m; 
                }
                else
                {
                    numberOfHoursOfLaborDecimal = Math.Truncate(numberOfHoursOfLaborDecimal); 
                }
            } 

        }

        
        /*CLOSES THE PROGRAM*/
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
    }
}



