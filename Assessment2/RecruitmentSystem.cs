using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BigRedRecruitment
{
    public class RecruitmentSystem

    {

        public List<Contractor> ContractorsList = new List<Contractor>();
        public List<Job> JobList = new List<Job>();

        private int contractCount = 0;
        private int jobCount = 0;
        private int newJobID = 0;
        int CompanyID = 0;

        public RecruitmentSystem()
        {
            
        JobList = new List<Job>()
            {
                new Job() 
               {
                   JobId = 1,
                   JobTitle= "Balcatta Stairs",
                   DateOpen = new DateOnly(2020, 3, 6) ,
                   CompletedDate= null ,
                   DateAllocated= new DateOnly(2020,7,7), 
                   Cost = 12500 ,
                   ContactorAssigned = null,
               },
                 new Job()
               {
                   JobId = 2,
                   JobTitle= "Ledderville Drainage",
                   DateOpen = new DateOnly(2023, 1, 2) ,
                   CompletedDate= null,
                   DateAllocated= null,
                   Cost = 70000 ,
                   ContactorAssigned = null,
               },
                new Job()
               {
                   JobId = 3,
                   JobTitle= "East Perth reataining wall",
                   DateOpen = new DateOnly(2022, 7, 9) ,
                   CompletedDate= null,
                   DateAllocated= new DateOnly(2022,10,10),
                   Cost = 12500 ,
                   ContactorAssigned = null,
               },
                new Job()
               {
                   JobId = 4,
                   JobTitle= "Subiaco road repair",
                   DateOpen = new DateOnly(2023, 2, 2) ,
                   CompletedDate= null,
                   DateAllocated= null,
                   Cost = 42000 ,
                   ContactorAssigned = null,
               },
                new Job()
               {
                   JobId = 5,
                   JobTitle= "Balcatta SkatePark",
                   DateOpen = new DateOnly(2022, 11, 5) ,
                   CompletedDate= null,
                   DateAllocated= new DateOnly(2020,7,7),
                   Cost = 150000 ,
                   ContactorAssigned = null,
               },
                new Job()
               {
                   JobId = 6,
                   JobTitle= "Osbourne Park Bridge",
                   DateOpen = new DateOnly(2020, 2, 2) ,
                   CompletedDate= new DateOnly(2021,3,3),
                   DateAllocated= new DateOnly(2020,3,1),
                   Cost = 205000 ,
                   ContactorAssigned = null,
               },
            };
        ContractorsList = new List<Contractor>()
            {
                new Contractor()
                {
                     CompanyID = 1,
                     FirstName = "Jeff" ,
                     LastName = "Davies",
                     HourlyWage = 70 ,
                     StartDate =  new DateOnly(2021, 2, 6) ,
                     EndDate = null,
                     AssginedJob = null
                },

                 new Contractor()
                {
                     CompanyID = 2,
                     FirstName = "Micheal" ,
                     LastName = "Scott",
                     HourlyWage = 75 ,
                     StartDate =  new DateOnly(2014, 1, 12) ,
                     EndDate = null,
                     AssginedJob = null

                },
                  new Contractor()
                {
                     CompanyID = 3,
                     FirstName = "Carl" ,
                     LastName = "Jung",
                     HourlyWage = 80 ,
                     StartDate =  new DateOnly(2012, 3, 9) ,
                     EndDate = new DateOnly(2022, 4, 4),
                     AssginedJob = null

                },
                   new Contractor()
                {
                     CompanyID = 4,
                     FirstName = "Walter" ,
                     LastName = "White",
                     HourlyWage = 120 ,
                     StartDate =  new DateOnly(2012, 3, 9) ,
                     EndDate = null,
                     AssginedJob = null

                },
                      new Contractor()
                {
                     CompanyID = 5,
                     FirstName = "Timothy" ,
                     LastName = "Leary",
                     HourlyWage = 100 ,
                     StartDate =  new DateOnly(2011, 2, 11) ,
                     EndDate = null,
                     AssginedJob = null

                }
            };

            JobList[0].ContactorAssigned = ContractorsList[2];
            JobList[2].ContactorAssigned = ContractorsList[1];
            JobList[3].ContactorAssigned = ContractorsList[3];
            ContractorsList[2].AssginedJob = JobList[0];
            ContractorsList[1].AssginedJob = JobList[2];
            ContractorsList[3].AssginedJob = JobList[3];
            
            contractCount = GetNewCompanyID();
            jobCount = GetNewJobID();
        }
        /// <summary>
        ///  This function takes in the Contractor object newCoontractor from the AddNewContractor window and adds it to the ContractorList
        /// The values are determined in AddNewContractor.xaml.cs
        /// The CompanyID is done here becaue I have a funstion GetNewCompanyID() that gets the highest value in the CompanyID
        /// in ContractorList and makes that into contractCount
        /// </summary>
        /// <param name="newContractor"></param>
        public void AddContractor(Contractor newContractor)
        {
            CompanyID  = contractCount + 1;
            newContractor.CompanyID = CompanyID;
            ContractorsList.Add(newContractor);       
           
        }/// <summary>
         /// This function gets the Contractor object selected in the combobox on the main menu and removes it from the Contractor List
         /// The line ContractorsList = ContractorsList.ToList(); is the way i chose to refresh the Contractopr list with the udated list of objects less the removed contractor 
         /// </summary>
         /// <param name="deleteContractor"></param>
        public void RemoveContractor(Contractor deleteContractor)
        {
            ContractorsList.Remove(deleteContractor);
            ContractorsList = ContractorsList.ToList();
        }
        /// <summary>
         /// This function takes in the Job object newJob from the AddNewJob window and adds it to the JobList
         /// The values are determined in AddNewJob.xaml.cs
         /// The JobID is doen here becaue I have a funstion GetNewJobID() that gets the highest value in the JObID
         /// in JobList and makes that into jobCount
         /// </summary>
         /// <param name="newJob"></param>
        public void AddJob( Job newJob)
        {
            newJobID = jobCount + 1;
            newJob.JobId = newJobID;
            JobList.Add(newJob);
           
        }
        /// <summary>
        /// This Function assgins a selectd Job to the selecetd Contractor The Objects are selected by a combobox selection and pass in to this function
        /// in this fuction the values of JobId and CompanyId are swapped over to indicate that a job is assgined to the contractor
        /// both list of objects are updated to show th changes made
        /// </summary>
        /// <param name="selectedJob"></param>
        /// <param name="selectedContractor"></param>
            public void  AssignJob( Job selectedJob, Contractor selectedContractor)
        {
            selectedJob.ContactorAssigned = selectedContractor;
            selectedContractor.AssginedJob = selectedJob;
            ContractorsList = ContractorsList.ToList();
            JobList = JobList.ToList();
        }
        /// <summary>
         /// This function takes a selected job object from the main window and marks the job as complete
         /// I have code that adds the date of when this done and turns the assgined contractor in Job class and the asgginedJob in Contacotr class to null
         /// both list of objects are updated to show th changes made
         /// </summary>
         /// <param name="selectedJob"></param>
        public void CompleteJob(Job selectedJob)
            {
            selectedJob.CompletedDate = DateOnly.FromDateTime(DateTime.Today);
            selectedJob.ContactorAssigned.AssginedJob = null;
            selectedJob.ContactorAssigned = null;
            ContractorsList = ContractorsList.ToList();
            JobList = JobList.ToList();
        }
            public double GetContractors()
            {
            // this is done in the combobox  on the main window i can see all contractors on there in realation to GetContractor
                return 0;
            }
            public double GetJobs()
            {
            // this is done in the combobox where all Jobs are shown in the drop down box
                return 0;
            }

        /// <summary>
        /// This function shows avbalible contractors by making a new List AvailbleContractors and looping through by the Contractor list
        /// It searches the AssignedJob vlaue for Null and if there a Null vlaue the object gets added to AvailbleContractors and returned to main window
        /// </summary>
        /// <returns></returns>
        public List<Contractor> GetAvaliableContractors(List<Contractor> contractorList)
        {
            List<Contractor> AvailableContractors = new List<Contractor>();
            foreach (var contractor in ContractorsList)
            {
                if (contractor.AssginedJob == null)
                {
                    AvailableContractors.Add(contractor);
                }
             
            }
            return AvailableContractors;
        }

        /// <summary>
        /// This function shows avalabile jobs by making a new List AvailbleJobs and looping through by the Job list
        /// It searches the DateAllocated value for Null and if there a Null value the object gets added to AvailbleJobs and returned to main window
        /// </summary>
        /// <returns></returns>
        public List<Job> GetAvaliableJobs(List<Job> jobList)
        {
            List<Job> AvailableJobs = new List<Job>();
            foreach (var job in JobList)
            {
                if (job.DateAllocated == null)
                {
                    AvailableJobs.Add(job);
                }

            }
            return AvailableJobs;
        }
    
     /// <summary>
     /// This function lopos through the Contractor list and scans the CompanyID value and return ths highest vlaue in the list
     /// I use the value as myContractCount 
     /// </summary>
     /// <returns></returns>     
        public  int GetNewCompanyID()
        {
                       int maxCompanyId = 0;
                        foreach (Contractor contractor in ContractorsList)
                        {
                            if (contractor.CompanyID > maxCompanyId)
                            {
                                maxCompanyId = contractor.CompanyID;
                            }
                        }
            return maxCompanyId;
            
        }
        /// <summary>
        /// This function loops through the Job list and scans the JobID value and return ths highest value in the list
        /// I use this value as my Jobcount 
        /// </summary>
        /// <returns></returns>
        public int GetNewJobID()
        {
            int maxJobId = 0;
            foreach (Job job in JobList)
            {
                if (job.JobId > maxJobId)
                {
                    maxJobId = job.JobId;
                }
            }
            return maxJobId;
        }
        /// <summary>
        /// This Function I have to varibales minCost and MaxCost which are obtained from a usewr input in the mainwindow
        /// I create a new Job List matchingJobs and then use a LINQ search to search the Job.Cost value and add those Job objects in the range the user has defined in the Main Window
        /// The list is returned to teh mainwidow and displayed 
        /// </summary>
        /// <param name="minCost"></param>
        /// <param name="maxCost"></param>
        /// <returns></returns>
        public List<Job> CostRangeSearch(int minCost, int maxCost, List<Job> joblist  )
        {
            List<Job> matchingJobs = JobList.Where(job => job.Cost >= minCost && job.Cost <= maxCost).ToList();

            return matchingJobs;
        }

    }
    }





