using System;

namespace L11
{
    delegate void ReportProgressMethod(int progress);
    public class calculator
    {
        public void CalculateSomething()
        {

        }

        public event ReportProgressMethod ProgressMethod;
    }
}