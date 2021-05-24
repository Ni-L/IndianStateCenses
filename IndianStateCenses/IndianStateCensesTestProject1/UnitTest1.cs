using NUnit.Framework;
using IndianStateCenses;
using System.Collections.Generic;

namespace IndianStateCensesTestProject1
{
    public class Tests
    {
        static string indiaStateCode = @"C:\Users\Aishwarya\source\repos\IndianStateCenses\IndianStateCenses\IndianStateCenses\csvfiles\IndiaStateCode.csv";
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        static string indianStateCensusFilePath = @"C:\Users\Aishwarya\source\repos\IndianStateCenses\IndianStateCenses\IndianStateCenses\csvfiles\IndiaStateCensusData.csv";
        static string wrongHeaderIndianCensusFile = @"C:\Users\Aishwarya\source\repos\IndianStateCenses\IndianStateCenses\IndianStateCenses\csvfiles\WrongIndiaStateCensusData.csv";
        static string IndianStateCodeFiletype = @"C:\Users\Aishwarya\source\repos\IndianStateCenses\IndianStateCenses\IndianStateCenses\csvfiles\IndiaStateCode.txt";
        static string delimeterIndianCensusCodeFilePath = @"C:\Users\Aishwarya\source\repos\IndianStateCenses\IndianStateCenses\IndianStateCenses\csvfiles\DelimiterIndiaStateCensusData.csv";
        static string wrongIndiaStateCensusData = @"C:\Users\Aishwarya\source\repos\IndianStateCenses\IndianStateCenses\IndianStateCenses\csvfiles\WrongIndiaStateCensusData.csv";
        static string wrongIndiaStateCode = @"C:\Users\Aishwarya\source\repos\IndianStateCenses\IndianStateCenses\IndianStateCenses\csvfiles\WrongIndiaStateCode.csv";
        static string delimiterIndiaStateCode = @"C:\Users\Aishwarya\source\repos\IndianStateCenses\IndianStateCenses\IndianStateCenses\csvfiles\DelimiterIndiaStateCode.csv";
        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }

        /// <summary>
        /// Test Case 1.1 Given the indian census data file when reader should return census data count.
        /// </summary>
        [Test]
        public void GivenIndianCensusDataFile_WhenReade_ThenShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Count);
        }

        /// <summary>
        /// Test Case 1.2 Given the indian census data file when incorrect then return File not found exception.
        /// </summary>
        [Test]
        public void GivenIndianCensusDataFile_WhenIncorrect_ThenShouldReturnFileNotFoundException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongHeaderIndianCensusFile, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.etype);
        }

        /// <summary>
        /// Test Case 1.3 Given the indian census data csv file when correct but type incoorect then return invalid file type exception.
        /// </summary>
        [Test]
        public void GivenIndianCensusDataFile_WhenCorrect_ThenShouldReturnInvalidFileTypeException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, IndianStateCodeFiletype, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.etype);
        }

        /// <summary>
        /// Test Case 1.4 Given the indian census data csv file when correct but delimiter incoorect then return incorrect delimiter exception.
        /// </summary>
        [Test]
        public void GivenIndianCensusDataFileCorrect_WhenDelimiterIncorrect_ThenShouldReturnInvalidDelimiterException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, delimeterIndianCensusCodeFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.etype);
        }

        /// <summary>
        /// Test Case 1.5 Given the indian census data csv file when correct but header incoorect then return incorrect delimiter exception.
        /// </summary>
        [Test]
        public void GivenIndianCensusDataFileCorrect_WhenHeaderIncorrect_ThenShouldReturnInvalidHeaderException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongHeaderIndianCensusFile, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.etype);
        }

        /// <summary>
        /// Test Case 2.1
        /// Getting the count of data in IndiaStateCodeData
        /// </summary>

        [Test]
        public void GivenIndianCodeDataFile_WhenReturnShouldReturnCodeCount()
        {
            //census Analyser Class is Called and parameters are passed like country, indian state census data which is csv file and header file.
            //add
            totalRecord = censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, indiaStateCode, indianStateCodeHeaders);
            //assert
            //total no of rows excluding header are 37 in indian state census data.
            Assert.AreEqual(37, totalRecord.Count);
        }
        [Test]
        /// <summary>
        /// checking the program for incorrect file name which do not exist
        /// test case 2.2
        /// </summary>
        public void GivenWrongIndianCodeDataFile_WhenReadedShouldReturnCustomException()
        {
            //census Analyser Class is Called and parameters are passed like country, indian state census data which is csv file and header file.
            //add
            var customException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndiaStateCensusData, indianStateCensusHeaders));
            //total no of rows excluding header are 29 in indian state census data.
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, customException.etype);
        }
        [Test]
        /// <summary>
        /// checking the program for incorrect file type which do not exist
        /// test case 2.3
        /// </summary>
        public void GivenWrongIndianCodeDataType_WhenReadedShouldReturnCustomException()
        {
            //census Analyser Class is Called and parameters are passed like country, indian state census data which is csv file and header file.
            //add
            var customException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, IndianStateCodeFiletype, indianStateCodeHeaders));
            //total no of rows excluding header are 36 in indian state census data.
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, customException.etype);
        }
        [Test]
        /// <summary>
        /// checking the program for incorrect delimiter is passed
        /// test case 2.4
        /// </summary>
        public void GivenIncorrectDelimiterForCodeData_WhenReadedShouldReturnCustomException()
        {
            //census Analyser Class is Called and parameters are passed like country, indian state census data which is csv file and header file.
            //add
            var customException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, delimiterIndiaStateCode, indianStateCodeHeaders));
            //total no of rows excluding header are 36 in indian state census data.
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, customException.etype);
        }
        [Test]
        /// <summary>
        /// checking the program for incorrect header is passed
        /// test case 2.5
        /// </summary>
        public void GivenIncorrectHeaderForCodeData_WhenReadedShouldReturnCustomException()
        {
            //census Analyser Class is Called and parameters are passed like country, indian state census data which is csv file and header file.
            //add
            var customException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndiaStateCode, indianStateCodeHeaders));
            //total no of rows excluding header are 36 in indian state census data.
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, customException.etype);
        }
    }
}
   