using System;

namespace FactoryMethodExercise1
{
    // "Product"
    abstract class Page
    {
    }

    // Concrete Products for resume
    class SkillsPage : Page
    {
        public GetPageName()
        { Console.WriteLine(“SkillsPage”) }
    }
    class EducationPage : Page
    {
        public GetPageName()
        { Console.WriteLine("EduationPage");
        }
    }
    class ExperiencePage : Page
    {
        public GetPageName()
        { Console.WriteLine(“ExperiencePage”) }
    }


    // Concrete Products for report
    class SummaryPage : Page
    {
        public GetPageName()
        { Console.WriteLine(“SummaryPage”) }
    }
    class IntroductionPage : Page
    {
        public GetPageName()
        { Console.WriteLine(“IntroductionPage”) }
    }
    class ResultsPage : Page
    {
        public GetPageName()
        { Console.WriteLine(“ResultsPage”) }
    }
    class ConclusionPage : Page
    {
        public GetPageName()
        { Console.WriteLine(“ConclusionPage”) }
    }

    // Abstract Creator Document
    abstract class Document
    {
        public ArrayList Pages = new ArrayList();
        // Constructor calls abstract Factory method
        public Document()
        {
            this.CreatePages();
        }
        public abstract GetDocName();
        // Factory Method
        public abstract void CreatePages();
    }


    // First Concrete Creator
    class Resume : Document
        {
            // Factory Method implementation
            public override void CreatePages()
            {
                Pages.Add(new SkillsPage());
                Pages.Add(new EducationPage());
                Pages.Add(new ExperiencePage());
            }
            public override void GetDocName()
            { Console.WriteLine("Resume");
            }
        }

        // Second Concrete Creator
        class Report : Document
        {
            // Factory Method implementation
            public override void CreatePages()
            {
                Pages.Add(new SummaryPage());
                Pages.Add(new IntroductionPage());
                Pages.Add(new ResultsPage());
                Pages.Add(new ConclusionPage());
            }
            public override void GetDocName()
            { Console.WriteLine("Report");
            }
        }

        // MainApp test application
        class MainApp
        {
            static void Main()
            {
                // Note: constructors call Factory Method
                Document[] documents = new Document[2];
                documents[0] = new Resume();
                documents[1] = new Report();
                // Display document pages
                foreach (Document document in documents)
                {
                    Console.WriteLine("\n" + document.GetDocName() + "--");
                    foreach (Page page in document.Pages)
                    {
                        Console.WriteLine(" " + page.GetPageName());
                    }
                }
            }
        }
    }