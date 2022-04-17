using NUnit.Framework;
using IndianCensus;

namespace CensusAnalyserTesting
{
    public class Tests
    {
        string folderPath = @"H:\Bridgelabz assignment\IndianCensus\IndianCensus\CSVFiles\";
        string validStateCensusFileState = "IndiaStateCensusData.csv";
        string invalidExtensionFileState = "IndiaStateCode.txt";
        string invalidDelimiterFileState = "DelimiterIndiaStateCensusData.csv";
        string invalidHeaderState = "WrongIndiaStateCensusData.csv";
        string validCensusFileStateCode = "IndiaStateCode.csv";
        string invalidExtensionFileStateCode = "IndiaStateCode.txt";
        string invalidDelimiterFileStateCode = "DelimiterIndiaStateCode.csv";
        string invalidHeaderstateCode = "WrongIndiaStateCode.csv";
        CensusAnalyser censusAnalyser;
        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
        }
        /// <summary>
        /// TC 1.1 - Data loaded or not
        /// </summary>
        [Test]
        public void Given_DataRecord_CSVfileAreSame()
        {
            censusAnalyser.data = censusAnalyser.LoadCensusData(folderPath + validStateCensusFileState, "State,Population,AreaInSqKm,DensityPerSqKm");
            Assert.AreEqual(29, censusAnalyser.data.Count);
        }
        /// <summary>
        /// TC1.2-  Given File is Exist or Not
        /// </summary>
        [Test]
        public void Given_IncorrectCSVFileName_ReturnCustomException()
        {
            CensusAnalyserException exception = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(folderPath + validStateCensusFileState + "XYZ", "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.File_Not_Exist, exception.type);
        }
        /// <summary>
        /// TC1.3-  Given File is Contains Proper extension or not
        /// </summary>
        [Test]
        public void Given_IncorrectFileType_ReturnCustomException()
        {
            CensusAnalyserException exception = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(folderPath + invalidExtensionFileState, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.Improper_Extension, exception.type);
        }
        /// <summary>
        /// TC1.4-  Proper delimeter is used or not
        /// </summary> 
        [Test]
        public void Given_IncorrectDelimiter_ReturnCustomException()
        {
            CensusAnalyserException exception = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(folderPath + invalidDelimiterFileState, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.Deliminator_Not_Found, exception.type);
        }
        /// <summary>
        /// TC1.5- DataHeader is not correct or not
        /// </summary>
        [Test]
        public void Given_IncorrectHeader_ReturnCustomException()
        {
            CensusAnalyserException exception = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(folderPath + invalidHeaderState, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.Incorrect_Header, exception.type);
        }
        /// <summary>
        /// TC2.1- Check to ensure the Number of Record matches or not
        /// </summary>
        [Test]
        public void Given_CSVCodeFile_TestRecordAreSame()
        {
            censusAnalyser.data = censusAnalyser.LoadCensusData(folderPath + validCensusFileStateCode, "SrNo,State Name,TIN,StateCode");
            Assert.AreEqual(37, censusAnalyser.data.Count);
        }
        /// <summary>
        /// TC 2.2 - Check Given CSV code File is Exist or Not
        /// </summary>
        [Test]
        public void Given_IncorrectCSVCodeFileName_ReturnCustomException()
        {
            CensusAnalyserException exception = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(folderPath + validCensusFileStateCode + "txt", "SrNo,State Name,TIN,StateCode"));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.File_Not_Exist, exception.type);
        }
        /// <summary>
        /// TC 2.3 - Check Given Code File is Contains Proper extension or not
        /// </summary>
        [Test]
        public void Given_IncorrectCodeFileType_ReturnCustomException()
        {
            CensusAnalyserException exception = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(folderPath + invalidExtensionFileStateCode, "SrNo,State Name,TIN,StateCode"));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.Improper_Extension, exception.type);
        }
        /// <summary>
        /// TC2.4- Check the Proper delimeter is used or not
        /// </summary> 
        [Test]
        public void GivenCodeFile_IncorrectDelimiter_ReturnCustomException()
        {
            CensusAnalyserException exception = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(folderPath + invalidDelimiterFileStateCode, "SrNo,State Name,TIN,StateCode"));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.Deliminator_Not_Found, exception.type);
        }
        /// <summary>
        /// TC2.5- Check in CSV Code file the Header is correct or not
        /// </summary>
        [Test]
        public void GivenCodeFile_IncorrectHeader_ReturnCustomException()
        {
            CensusAnalyserException exception = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(folderPath + invalidHeaderstateCode, "SrNo,State Name,TIN,StateCode"));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.Incorrect_Header, exception.type);
        }
    }
}
