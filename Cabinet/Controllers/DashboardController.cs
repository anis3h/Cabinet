﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cabinet.Models.CabinetViewModel.Dashboard;
using Core.Interfaces;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Syncfusion;

namespace Cabinet.Controllers
{
    public class DashboardController : Controller
    {
        IPatientRepository _patientRepository;

       public DashboardController(IPatientRepository patientRepository)
       {
            _patientRepository = patientRepository;
            Syncfusion.EJ2.Charts.ChartMajorGridLines test = new Syncfusion.EJ2.Charts.ChartMajorGridLines();
       }

        public async Task<IActionResult> Index()
        {
            //List<LineChartData> chartData = new List<LineChartData>
            //{
            //    new LineChartData { xValue = new DateTime(2005, 01, 01), yValue = 21, yValue1 = 28 },
            //    new LineChartData { xValue = new DateTime(2006, 01, 01), yValue = 24, yValue1 = 44 },
            //    new LineChartData { xValue = new DateTime(2007, 01, 01), yValue = 36, yValue1 = 48 },
            //    new LineChartData { xValue = new DateTime(2008, 01, 01), yValue = 38, yValue1 = 50 },
            //    new LineChartData { xValue = new DateTime(2009, 01, 01), yValue = 54, yValue1 = 66 },
            //    new LineChartData { xValue = new DateTime(2010, 01, 01), yValue = 57, yValue1 = 78 },
            //    new LineChartData { xValue = new DateTime(2011, 01, 01), yValue = 70, yValue1 = 84 },
            //};
            var chartData = await _patientRepository.GetGeburtsDatumCountByYears();
            ViewBag.dataSource = chartData;
            return View();
        }  
    }

   


    //public class LineChartData
    //{
    //    public DateTime xValue;
    //    public double yValue;
    //    public double yValue1;
    //}
}