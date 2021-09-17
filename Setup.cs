using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoRestExemplo
{
    public class Setup
    {
        [OneTimeSetUp]
        public void ExecutarAntesDeCadaTeste()
        {

        }

        [OneTimeTearDown]
        public void ExecutarDepoisDeCadaTeste()
        {

        }
    }
}
