using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

#region Notes

/*
1) All the database coding should be present inside this file
2) To communicate with the database you would require a connection string from web.config file to connect to the database
3) Create an instance of PersonDataContext class, which is inside Person.dbml
4) The above class is the one that talks with the db.
5) If you mouse over the datacontext in PersonDataContext you can see, the datacontext is the main entry point for linq to sql framework,
since the PersonDataContext is inheriting from the datacontext, we are creating an instance of 
Person data context in this file to communicate with the database
6)Model doesn't talk with view or View doesn't talk with Model. Model -> Controller -> View
View -> Controller -> Model
*/

#endregion

namespace StateManagement.Models
{
    public class PersonDAL
    {
        // Create an instance of the datacontext (we don't have a default constructor, we are required to pass the connection string by reading it from web.config)
        PersonDataContext DataContext = new PersonDataContext(ConfigurationManager.ConnectionStrings["masterConnectionString"].ConnectionString);

        /*
        Now we have established the connection. We can now talk with the database. We can define methods 
        for inserting, reading, updating and deleting records in the database 
        */

        // Let's start with the select method to get all the people(from older to younger) who are male from PERSON table
        public List<PERSON> GetPeople()
        {
            // The reason for converting everything to list is we are running a linq statement on a Table called PERSON.
            // So, the return type is going to be table. But here, the return type is list. so, we are converting everything to list
            // NOTE : It's better the pass the list data to the views 
            try
            {
                return (from p in DataContext.PERSONs select p).ToList();
            }
            // controller gets this execption and it will prompt the user about this exception
            catch (Exception ex)
            {
                throw ex;
            }
        // Now you are done with the select method in the dal class. Now, create an instance of this dal
        // class in the controller. 
        }

        // Method to add data to the PERSON table
        public void InsertPersonRecord(PERSON per)
        {
            /*
             * In orm, tables -> classes, columns -> properties, records -> instances
            */
            try
            {
                // saves the instace in the local table
                DataContext.PERSONs.InsertOnSubmit(per);
                // commit the changes to the actual db
                DataContext.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // Method to read one record 
        public PERSON SelectRecord(int p_id)
        {
            try
            {
                PERSON P = (from p in DataContext.PERSONs where p.p_id == p_id select p).Single();
                return P;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}