/* Title:           Create ID Class
 * Date:            4-27-16
 * Author:          Terry Holmes
 *
 * Description:     This class will make the id for TWC Inventory */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewEventLogDLL;

namespace CreateIDDLL
{
    public class CreateIDClass
    {
        //setting up the classes
        EventLogClass TheEventLogClass = new EventLogClass();

        //setting up the data
        CreateIDDataSet aCreateIDDataSet;
        CreateIDDataSetTableAdapters.CreateIDTableAdapter aCreateIDTableAdapter;

        //creating the id
        public int CreateInventoryID()
        {
            //setting local variables
            int intTransactionID = 0;

            try
            {
                //setting up the data
                aCreateIDDataSet = new CreateIDDataSet();
                aCreateIDTableAdapter = new CreateIDDataSetTableAdapters.CreateIDTableAdapter();
                aCreateIDTableAdapter.Fill(aCreateIDDataSet.CreateID);

                //creating the id
                intTransactionID = aCreateIDDataSet.CreateID[0].CreatedID;
                intTransactionID++;

                //updating the data
                aCreateIDDataSet.CreateID[0].CreatedID = intTransactionID;
                aCreateIDTableAdapter.Update(aCreateIDDataSet.CreateID);
            }
            catch (Exception Ex)
            {
                //event log entry
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Create ID Class Create Inventory ID " + Ex.Message);
            }

            //returning value
            return intTransactionID;
        }
    }
}
