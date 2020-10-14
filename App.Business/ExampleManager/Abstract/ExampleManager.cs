using App.Business.ExampleManager.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Business.ExampleManager.Abstract
{
    public class ExampleManager:IExampleManager
    {
       //  public  DbContext _dbContext { get; set; }
        public ExampleManager(/*DbContext dbContext*/)
        {
           // _dbContext = dbContext;
        }
        public bool getExampleValue()
        {
            return true;
        }

    }
}
