using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace SyncfusionTreeView
{
    using System.Windows.Input;
    using Microsoft.Maui.Controls;
    using Syncfusion.TreeView.Engine;
    using System.Threading.Tasks;

    public class TreeViewViewModel
    {
        #region Public Properties

        public ObservableCollection<TreeViewModel>? Nodes { get; set; }

        // Command for load-on-demand
        public ICommand? TreeViewOnDemandCommand { get; set; }

        #endregion

        #region Constructor

        public TreeViewViewModel()
        {
            // Initialize load-on-demand command
            this.TreeViewOnDemandCommand = new Command<object?>(ExecuteOnDemandLoading, CanExecuteOnDemandLoading);
        }

        #endregion

        #region LoadOnDemand

        private bool CanExecuteOnDemandLoading(object? sender)
        {
            try
            {
                var node = sender as TreeViewNode;
                var content = node?.Content as TreeViewModel;
                return content != null && content.HasChildren;
            }
            catch
            {
                return false;
            }
        }

        private void ExecuteOnDemandLoading(object? obj)
        {
            var node = obj as TreeViewNode;
            if (node == null)
                return;

            // Skip repeated population
            if (node.ChildNodes != null && node.ChildNodes.Count > 0)
            {
                node.IsExpanded = true;
                return;
            }

            node.ShowExpanderAnimation = true;

            var content = node.Content as TreeViewModel;

            Application.Current?.Dispatcher.Dispatch(async () =>
            {
                await Task.Delay(250); // simulate fetch
                if (content?.Children != null)
                {
                    // Populate child nodes from the model's Children collection
                    node.PopulateChildNodes(content.Children);
                    if (node.ChildNodes != null && node.ChildNodes.Count > 0)
                        node.IsExpanded = true;
                }
                node.ShowExpanderAnimation = false;
            });
        }

        #endregion

        #region Private Methods

        // Generates a company structure as tree nodes
        internal void GenerateCompanyHierarchy()
        {
            var nodes = new ObservableCollection<TreeViewModel>();
            // In AddCompany adding 100 items. so dividing items by 100.
            for (int i = 1; i<= Extensions.toatlItemsCount/100; i++)
            {
                AddCompany(nodes);
            }

            this.Nodes = nodes;
        }

        private void AddCompany(ObservableCollection<TreeViewModel> nodes)
        {
            var company = new TreeViewModel("Tech Corp - Leading IT Solutions Provider");

            // Assemble the full tree
            company.Children.Add(AddHRDep());
            company.Children.Add(AddITDep());
            company.Children.Add(AddFinanceSep());
            company.Children.Add(AddSalesDep());
            company.Children.Add(AddMarketingDep());
            company.Children.Add(AddResearchDevlopmentDept());

            nodes.Add(company);
        }
        
        private TreeViewModel AddHRDep()
        {
            // Human Resources Department
            var hrDepartment = new TreeViewModel("Human Resources - Manages hiring, training, and employee relations");

            // Recruitment Process (with 4-level hierarchy)
            var recruitment = new TreeViewModel("Recruitment - Hiring new employees and onboarding");
            var jobPosting = new TreeViewModel("Job Posting - Creating and sharing job advertisements");
            jobPosting.Children.Add(new TreeViewModel("Define Job Requirements - Identify skills and experience needed"));
            jobPosting.Children.Add(new TreeViewModel("Write Job Description - Create detailed job postings"));
            jobPosting.Children.Add(new TreeViewModel("Post on Platforms - Publish on LinkedIn, company website, etc."));

            var candidateScreening = new TreeViewModel("Candidate Screening - Reviewing applications and resumes");
            candidateScreening.Children.Add(new TreeViewModel("Resume Shortlisting - Filtering applicants based on qualifications"));
            candidateScreening.Children.Add(new TreeViewModel("Initial Phone Screening - Conducting preliminary interviews"));
            candidateScreening.Children.Add(new TreeViewModel("Skill Assessment - Administering technical tests"));

            var interviewProcess = new TreeViewModel("Interview Process - Conducting in-depth evaluations");
            interviewProcess.Children.Add(new TreeViewModel("HR Interview - Assessing cultural fit and soft skills"));
            interviewProcess.Children.Add(new TreeViewModel("Technical Interview - Testing job-specific knowledge"));
            interviewProcess.Children.Add(new TreeViewModel("Final Interview - Decision-making by senior management"));

            var onboarding = new TreeViewModel("Onboarding - Integrating new employees into the company");
            onboarding.Children.Add(new TreeViewModel("Offer Letter - Sending official job offers"));
            onboarding.Children.Add(new TreeViewModel("Employee Orientation - Introduction to company culture and policies"));
            onboarding.Children.Add(new TreeViewModel("Training Sessions - Initial training on tools and responsibilities"));

            recruitment.Children.Add(jobPosting);
            recruitment.Children.Add(candidateScreening);
            recruitment.Children.Add(interviewProcess);
            recruitment.Children.Add(onboarding);
            hrDepartment.Children.Add(recruitment);

            // Employee Relations (with 4-level hierarchy)
            var employeeRelations = new TreeViewModel("Employee Relations - Handling workplace policies and culture");
            var grievanceHandling = new TreeViewModel("Grievance Handling - Managing employee concerns and disputes");
            grievanceHandling.Children.Add(new TreeViewModel("Policy Compliance - Ensuring adherence to company policies"));
            grievanceHandling.Children.Add(new TreeViewModel("Conflict Resolution - Addressing workplace disputes"));
            grievanceHandling.Children.Add(new TreeViewModel("Legal Support - Providing assistance on labor laws"));

            var employeeEngagement = new TreeViewModel("Employee Engagement - Boosting morale and productivity");
            employeeEngagement.Children.Add(new TreeViewModel("Surveys & Feedback - Collecting employee opinions"));
            employeeEngagement.Children.Add(new TreeViewModel("Wellness Programs - Promoting mental and physical health"));
            employeeEngagement.Children.Add(new TreeViewModel("Team Building Activities - Organizing corporate events"));

            employeeRelations.Children.Add(grievanceHandling);
            employeeRelations.Children.Add(employeeEngagement);
            hrDepartment.Children.Add(employeeRelations);

            // Payroll (with 4-level hierarchy)
            var payroll = new TreeViewModel("Payroll - Salary processing and benefits management");
            var salaryProcessing = new TreeViewModel("Salary Processing - Managing employee compensation");
            salaryProcessing.Children.Add(new TreeViewModel("Payroll Calculation - Determining net pay"));
            salaryProcessing.Children.Add(new TreeViewModel("Tax Deductions - Managing tax withholdings"));
            salaryProcessing.Children.Add(new TreeViewModel("Salary Disbursement - Ensuring timely payment"));

            var benefitsManagement = new TreeViewModel("Benefits Management - Overseeing employee perks");
            benefitsManagement.Children.Add(new TreeViewModel("Health Insurance - Managing medical benefits"));
            benefitsManagement.Children.Add(new TreeViewModel("Retirement Plans - Handling pension schemes"));
            benefitsManagement.Children.Add(new TreeViewModel("Leave Policy - Tracking vacation and sick leaves"));

            payroll.Children.Add(salaryProcessing);
            payroll.Children.Add(benefitsManagement);
            hrDepartment.Children.Add(payroll);

            return hrDepartment;
        }

        private TreeViewModel AddITDep()
        {
            // IT Department
            var itDepartment = new TreeViewModel("IT Department - Oversees software development and infrastructure");

            // Software Development Team
            var devTeam = new TreeViewModel("Software Development - Builds applications and platforms");

            // Frontend Team (4th Level)
            var frontendTeam = new TreeViewModel("Frontend Team - Develops UI/UX and web applications");
            frontendTeam.Children.Add(new TreeViewModel("UI/UX Design - Creating user-friendly interfaces"));
            frontendTeam.Children.Add(new TreeViewModel("Web Development - Building React/Angular apps"));
            frontendTeam.Children.Add(new TreeViewModel("Mobile Development - Developing iOS/Android apps"));

            var backendTeam = new TreeViewModel("Backend Team - Manages databases, APIs, and server logic");
            backendTeam.Children.Add(new TreeViewModel("Database Management - Handling SQL/NoSQL databases"));
            backendTeam.Children.Add(new TreeViewModel("API Development - Creating REST/GraphQL services"));
            backendTeam.Children.Add(new TreeViewModel("Authentication & Security - Implementing OAuth, JWT, and access control"));

            var devOpsTeam = new TreeViewModel("DevOps Team - Automates deployments and manages cloud services");
            devOpsTeam.Children.Add(new TreeViewModel("CI/CD Pipelines - Automating builds and deployments"));
            devOpsTeam.Children.Add(new TreeViewModel("Cloud Infrastructure - Managing AWS, Azure, GCP services"));
            devOpsTeam.Children.Add(new TreeViewModel("Monitoring & Logging - Ensuring uptime and system health"));

            // Add teams to Software Development
            devTeam.Children.Add(frontendTeam);
            devTeam.Children.Add(backendTeam);
            devTeam.Children.Add(devOpsTeam);

            // IT Support Team
            var supportTeam = new TreeViewModel("IT Support - Provides tech assistance and maintenance");

            // Helpdesk (4th Level)
            var helpdesk = new TreeViewModel("Helpdesk - Resolves software and hardware issues");
            helpdesk.Children.Add(new TreeViewModel("Ticket Management - Handling user support requests"));
            helpdesk.Children.Add(new TreeViewModel("Software Installation - Deploying business applications"));
            helpdesk.Children.Add(new TreeViewModel("Remote Troubleshooting - Assisting employees via remote access"));

            var infrastructureTeam = new TreeViewModel("Infrastructure Team - Manages networks, servers, and cybersecurity");
            infrastructureTeam.Children.Add(new TreeViewModel("Network Administration - Configuring routers, firewalls, VPNs"));
            infrastructureTeam.Children.Add(new TreeViewModel("Server Management - Maintaining on-premise/cloud servers"));
            infrastructureTeam.Children.Add(new TreeViewModel("Cybersecurity - Protecting systems from threats and vulnerabilities"));

            // Add teams to IT Support
            supportTeam.Children.Add(helpdesk);
            supportTeam.Children.Add(infrastructureTeam);

            // Add everything to IT Department
            itDepartment.Children.Add(devTeam);
            itDepartment.Children.Add(supportTeam);
            return itDepartment;
        }

        private TreeViewModel AddFinanceSep()
        {
            // Finance Department
            var financeDepartment = new TreeViewModel("Finance Department - Handles company financial operations");

            // Accounts Payable (4th Level)
            var accountsPayable = new TreeViewModel("Accounts Payable - Manages vendor payments");
            accountsPayable.Children.Add(new TreeViewModel("Invoice Processing - Reviewing and approving invoices"));
            accountsPayable.Children.Add(new TreeViewModel("Payment Processing - Handling check, wire transfer, and ACH payments"));
            accountsPayable.Children.Add(new TreeViewModel("Expense Reimbursement - Processing employee claims"));

            // Accounts Receivable (4th Level)
            var accountsReceivable = new TreeViewModel("Accounts Receivable - Tracks incoming payments");
            accountsReceivable.Children.Add(new TreeViewModel("Customer Invoicing - Generating and sending invoices"));
            accountsReceivable.Children.Add(new TreeViewModel("Payment Collection - Following up on outstanding invoices"));
            accountsReceivable.Children.Add(new TreeViewModel("Revenue Recognition - Ensuring accurate financial reporting"));

            // Auditing (4th Level)
            var auditing = new TreeViewModel("Auditing - Ensures financial compliance and risk management");
            auditing.Children.Add(new TreeViewModel("Internal Audits - Reviewing company financial records"));
            auditing.Children.Add(new TreeViewModel("External Audits - Coordinating with third-party auditors"));
            auditing.Children.Add(new TreeViewModel("Regulatory Compliance - Ensuring adherence to financial regulations"));

            // Budgeting & Forecasting (4th Level)
            var budgeting = new TreeViewModel("Budgeting & Forecasting - Planning financial expenditures and projections");
            budgeting.Children.Add(new TreeViewModel("Annual Budget Planning - Setting company-wide financial goals"));
            budgeting.Children.Add(new TreeViewModel("Financial Forecasting - Predicting revenue and expenses"));
            budgeting.Children.Add(new TreeViewModel("Variance Analysis - Comparing actual vs. projected figures"));

            // Taxation (4th Level)
            var taxation = new TreeViewModel("Taxation - Manages company tax filings and compliance");
            taxation.Children.Add(new TreeViewModel("Corporate Tax Filing - Submitting tax returns"));
            taxation.Children.Add(new TreeViewModel("Tax Deductions - Maximizing eligible business deductions"));
            taxation.Children.Add(new TreeViewModel("GST & VAT Compliance - Handling goods and services taxes"));

            // Treasury & Investment (4th Level)
            var treasury = new TreeViewModel("Treasury & Investment - Manages cash flow and investments");
            treasury.Children.Add(new TreeViewModel("Cash Flow Management - Ensuring liquidity for operations"));
            treasury.Children.Add(new TreeViewModel("Investment Planning - Allocating funds for business growth"));
            treasury.Children.Add(new TreeViewModel("Risk Management - Hedging against financial risks"));

            // Add everything to Finance Department
            financeDepartment.Children.Add(accountsPayable);
            financeDepartment.Children.Add(accountsReceivable);
            financeDepartment.Children.Add(auditing);
            financeDepartment.Children.Add(budgeting);
            financeDepartment.Children.Add(taxation);
            financeDepartment.Children.Add(treasury);
            return financeDepartment;
        }

        private TreeViewModel AddSalesDep()
        {
            // Sales Department
            var salesDepartment = new TreeViewModel("Sales Department - Drives revenue and client relationships");

            // Domestic Sales (4th Level)
            var domesticSales = new TreeViewModel("Domestic Sales - Manages local market sales");

            // Retail Sales
            var retailSales = new TreeViewModel("Retail Sales - Sells products directly to consumers");
            retailSales.Children.Add(new TreeViewModel("In-Store Sales - Managing walk-in customers"));
            retailSales.Children.Add(new TreeViewModel("Online Sales - E-commerce and digital platforms"));
            retailSales.Children.Add(new TreeViewModel("Customer Engagement - Loyalty programs and promotions"));

            // Enterprise Sales
            var enterpriseSales = new TreeViewModel("Enterprise Sales - Handles large business clients");
            enterpriseSales.Children.Add(new TreeViewModel("B2B Sales - Selling to corporate clients"));
            enterpriseSales.Children.Add(new TreeViewModel("Key Account Management - Maintaining high-value customer relationships"));
            enterpriseSales.Children.Add(new TreeViewModel("Proposal & Contract Negotiation - Closing high-ticket deals"));

            // Add to Domestic Sales
            domesticSales.Children.Add(retailSales);
            domesticSales.Children.Add(enterpriseSales);

            // International Sales (4th Level)
            var internationalSales = new TreeViewModel("International Sales - Expands business globally");

            // Europe Market
            var europeMarket = new TreeViewModel("Europe Market - Sales operations in Europe");
            europeMarket.Children.Add(new TreeViewModel("EU Compliance - Meeting trade regulations"));
            europeMarket.Children.Add(new TreeViewModel("Local Partnerships - Collaborating with European distributors"));
            europeMarket.Children.Add(new TreeViewModel("Multi-Currency Pricing - Handling diverse financial transactions"));

            // Asia Market
            var asiaMarket = new TreeViewModel("Asia Market - Sales expansion in Asia");
            asiaMarket.Children.Add(new TreeViewModel("Regional Distributors - Managing suppliers and logistics"));
            asiaMarket.Children.Add(new TreeViewModel("Market Localization - Adapting sales strategies to cultural trends"));
            asiaMarket.Children.Add(new TreeViewModel("Trade Shows & Exhibitions - Participating in industry events"));

            // North America Market
            var northAmericaMarket = new TreeViewModel("North America Market - Business growth in the USA & Canada");
            northAmericaMarket.Children.Add(new TreeViewModel("Government Contracts - Bidding for public sector deals"));
            northAmericaMarket.Children.Add(new TreeViewModel("E-Commerce Growth - Expanding online retail presence"));
            northAmericaMarket.Children.Add(new TreeViewModel("Customer Support & Retention - Building brand loyalty"));

            // Add to International Sales
            internationalSales.Children.Add(europeMarket);
            internationalSales.Children.Add(asiaMarket);
            internationalSales.Children.Add(northAmericaMarket);

            // Add to Sales Department
            salesDepartment.Children.Add(domesticSales);
            salesDepartment.Children.Add(internationalSales);
            return salesDepartment;
        }
        
        private TreeViewModel AddMarketingDep()
        {
            // Marketing Department
            var marketingDepartment = new TreeViewModel("Marketing Department - Promotes brand and drives customer engagement");

            // Digital Marketing (4th Level)
            var digitalMarketing = new TreeViewModel("Digital Marketing - Manages social media, SEO, and PPC campaigns");

            // SEO & Content Optimization
            var seoContent = new TreeViewModel("SEO & Content Optimization - Improves search rankings and organic traffic");
            seoContent.Children.Add(new TreeViewModel("Keyword Research - Identifying high-performing search terms"));
            seoContent.Children.Add(new TreeViewModel("On-Page Optimization - Enhancing website content for search engines"));
            seoContent.Children.Add(new TreeViewModel("Link Building - Increasing domain authority with backlinks"));

            // Social Media Marketing
            var socialMedia = new TreeViewModel("Social Media Marketing - Engages audiences across platforms");
            socialMedia.Children.Add(new TreeViewModel("Content Scheduling - Planning and automating posts"));
            socialMedia.Children.Add(new TreeViewModel("Community Management - Responding to customer interactions"));
            socialMedia.Children.Add(new TreeViewModel("Influencer Collaborations - Partnering with industry influencers"));

            // Paid Advertising (PPC)
            var ppcAdvertising = new TreeViewModel("Paid Advertising (PPC) - Runs paid campaigns on Google and social media");
            ppcAdvertising.Children.Add(new TreeViewModel("Google Ads - Managing search and display campaigns"));
            ppcAdvertising.Children.Add(new TreeViewModel("Facebook & Instagram Ads - Targeting audience through social platforms"));
            ppcAdvertising.Children.Add(new TreeViewModel("Conversion Rate Optimization - Enhancing ad performance"));

            // Add to Digital Marketing
            digitalMarketing.Children.Add(seoContent);
            digitalMarketing.Children.Add(socialMedia);
            digitalMarketing.Children.Add(ppcAdvertising);

            // Content Creation (4th Level)
            var contentCreation = new TreeViewModel("Content Creation - Produces blogs, videos, and advertising materials");

            // Blogging & Articles
            var blogging = new TreeViewModel("Blogging & Articles - Creates informative and engaging written content");
            blogging.Children.Add(new TreeViewModel("Industry Blogs - Publishing thought leadership articles"));
            blogging.Children.Add(new TreeViewModel("Case Studies - Showcasing successful customer experiences"));
            blogging.Children.Add(new TreeViewModel("E-books & Whitepapers - Providing in-depth insights"));

            // Video & Multimedia
            var videoMarketing = new TreeViewModel("Video & Multimedia - Produces promotional and educational videos");
            videoMarketing.Children.Add(new TreeViewModel("YouTube Marketing - Growing brand presence via video content"));
            videoMarketing.Children.Add(new TreeViewModel("Webinars & Live Streams - Engaging audiences in real-time"));
            videoMarketing.Children.Add(new TreeViewModel("Short-Form Videos - TikTok, Instagram Reels, and YouTube Shorts"));

            // Graphic Design & Branding
            var graphicDesign = new TreeViewModel("Graphic Design & Branding - Creates visually appealing marketing materials");
            graphicDesign.Children.Add(new TreeViewModel("Logo & Brand Identity - Defining visual identity"));
            graphicDesign.Children.Add(new TreeViewModel("Infographics - Simplifying complex topics visually"));
            graphicDesign.Children.Add(new TreeViewModel("Print & Digital Ads - Designing banners, flyers, and online ads"));

            // Add to Content Creation
            contentCreation.Children.Add(blogging);
            contentCreation.Children.Add(videoMarketing);
            contentCreation.Children.Add(graphicDesign);

            // Public Relations (4th Level)
            var publicRelations = new TreeViewModel("Public Relations - Builds media relationships and brand reputation");

            // Media Outreach
            var mediaOutreach = new TreeViewModel("Media Outreach - Manages press releases and journalist relations");
            mediaOutreach.Children.Add(new TreeViewModel("Press Releases - Announcing company news and updates"));
            mediaOutreach.Children.Add(new TreeViewModel("Media Interviews - Coordinating executive appearances"));
            mediaOutreach.Children.Add(new TreeViewModel("Crisis Management - Handling PR emergencies and reputation risks"));

            // Event Marketing
            var eventMarketing = new TreeViewModel("Event Marketing - Organizes brand events and sponsorships");
            eventMarketing.Children.Add(new TreeViewModel("Trade Shows - Showcasing products at industry expos"));
            eventMarketing.Children.Add(new TreeViewModel("Webinars & Conferences - Hosting online and in-person events"));
            eventMarketing.Children.Add(new TreeViewModel("Sponsorships - Partnering with brands and organizations"));

            // Brand Reputation
            var brandReputation = new TreeViewModel("Brand Reputation - Manages public perception and company image");
            brandReputation.Children.Add(new TreeViewModel("Online Reviews & Feedback - Monitoring and responding to customer reviews"));
            brandReputation.Children.Add(new TreeViewModel("Corporate Social Responsibility - Engaging in sustainability and ethical branding"));
            brandReputation.Children.Add(new TreeViewModel("Media Crisis Handling - Mitigating negative PR impact"));

            // Add to Public Relations
            publicRelations.Children.Add(mediaOutreach);
            publicRelations.Children.Add(eventMarketing);
            publicRelations.Children.Add(brandReputation);

            // Add everything to Marketing Department
            marketingDepartment.Children.Add(digitalMarketing);
            marketingDepartment.Children.Add(contentCreation);
            marketingDepartment.Children.Add(publicRelations);
            return marketingDepartment;
        }

        private TreeViewModel AddResearchDevlopmentDept()
        {
            // Research & Development
            var rAndDDepartment = new TreeViewModel("R&D Department - Innovates new technologies and product improvements");

            // AI & Machine Learning (4th Level)
            var aiML = new TreeViewModel("AI & Machine Learning - Develops AI-based solutions");

            // Natural Language Processing (NLP)
            var nlp = new TreeViewModel("Natural Language Processing (NLP) - Advances AI in language understanding");
            nlp.Children.Add(new TreeViewModel("Chatbot Development - Creating virtual assistants for customer support"));
            nlp.Children.Add(new TreeViewModel("Speech Recognition - Improving voice-controlled applications"));
            nlp.Children.Add(new TreeViewModel("Text Analytics - Extracting insights from large text datasets"));

            // Computer Vision
            var computerVision = new TreeViewModel("Computer Vision - Enables AI-powered image and video analysis");
            computerVision.Children.Add(new TreeViewModel("Facial Recognition - Identifying and authenticating individuals"));
            computerVision.Children.Add(new TreeViewModel("Object Detection - Recognizing objects in images and videos"));
            computerVision.Children.Add(new TreeViewModel("Augmented Reality (AR) - Enhancing real-world experiences with AI"));

            // Deep Learning & Neural Networks
            var deepLearning = new TreeViewModel("Deep Learning & Neural Networks - Builds AI-driven automation");
            deepLearning.Children.Add(new TreeViewModel("Neural Network Optimization - Enhancing AI model accuracy"));
            deepLearning.Children.Add(new TreeViewModel("AI-powered Analytics - Automating business insights"));
            deepLearning.Children.Add(new TreeViewModel("Reinforcement Learning - AI self-improvement through experience"));

            // Add to AI & ML
            aiML.Children.Add(nlp);
            aiML.Children.Add(computerVision);
            aiML.Children.Add(deepLearning);

            // Cybersecurity Research (4th Level)
            var cyberSecurity = new TreeViewModel("Cybersecurity Research - Enhances security against cyber threats");

            // Threat Intelligence
            var threatIntelligence = new TreeViewModel("Threat Intelligence - Identifies and prevents cyber threats");
            threatIntelligence.Children.Add(new TreeViewModel("Malware Analysis - Detecting and mitigating malicious software"));
            threatIntelligence.Children.Add(new TreeViewModel("Network Security - Protecting internal IT infrastructure"));
            threatIntelligence.Children.Add(new TreeViewModel("Data Encryption - Ensuring secure communication and storage"));

            // Ethical Hacking & Penetration Testing
            var ethicalHacking = new TreeViewModel("Ethical Hacking & Penetration Testing - Simulating attacks for security");
            ethicalHacking.Children.Add(new TreeViewModel("Vulnerability Assessment - Identifying weaknesses in systems"));
            ethicalHacking.Children.Add(new TreeViewModel("Penetration Testing - Simulated cyberattacks for security evaluation"));
            ethicalHacking.Children.Add(new TreeViewModel("Red Teaming - Testing security defenses through real-world attacks"));

            // AI & Automation in Security
            var aiSecurity = new TreeViewModel("AI & Automation in Security - Enhancing cybersecurity using AI");
            aiSecurity.Children.Add(new TreeViewModel("Anomaly Detection - Identifying suspicious behavior patterns"));
            aiSecurity.Children.Add(new TreeViewModel("Automated Incident Response - AI-driven security alerts and actions"));
            aiSecurity.Children.Add(new TreeViewModel("Biometric Security - Using AI for facial and fingerprint recognition"));

            // Add to Cybersecurity Research
            cyberSecurity.Children.Add(threatIntelligence);
            cyberSecurity.Children.Add(ethicalHacking);
            cyberSecurity.Children.Add(aiSecurity);

            // New Product Development (4th Level)
            var newProductDev = new TreeViewModel("New Product Development - Designs and tests new products");

            // Product Concept & Design
            var productConcept = new TreeViewModel("Product Concept & Design - Ideation and early development");
            productConcept.Children.Add(new TreeViewModel("Market Research - Identifying industry trends and needs"));
            productConcept.Children.Add(new TreeViewModel("Prototyping - Creating early-stage models of new products"));
            productConcept.Children.Add(new TreeViewModel("Usability Testing - Evaluating product effectiveness with users"));

            // Testing & Quality Assurance
            var testingQA = new TreeViewModel("Testing & Quality Assurance - Ensuring product reliability");
            testingQA.Children.Add(new TreeViewModel("Software Testing - Identifying bugs in applications and systems"));
            testingQA.Children.Add(new TreeViewModel("Hardware Testing - Evaluating durability of physical products"));
            testingQA.Children.Add(new TreeViewModel("Regulatory Compliance - Ensuring adherence to safety and industry standards"));

            // Manufacturing & Production
            var manufacturing = new TreeViewModel("Manufacturing & Production - Scaling new products for market");
            manufacturing.Children.Add(new TreeViewModel("Supply Chain Optimization - Reducing costs and increasing efficiency"));
            manufacturing.Children.Add(new TreeViewModel("Automated Production - Implementing AI in manufacturing"));
            manufacturing.Children.Add(new TreeViewModel("Product Launch Strategies - Planning go-to-market execution"));

            // Add to New Product Development
            newProductDev.Children.Add(productConcept);
            newProductDev.Children.Add(testingQA);
            newProductDev.Children.Add(manufacturing);

            // Add all categories to R&D Department
            rAndDDepartment.Children.Add(aiML);
            rAndDDepartment.Children.Add(cyberSecurity);
            rAndDDepartment.Children.Add(newProductDev);

            return rAndDDepartment;
        }

        #endregion
    }
}
