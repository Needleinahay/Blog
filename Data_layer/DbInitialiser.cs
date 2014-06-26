using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using Models;

namespace Blog
{
    
    public class DbInitialiser : DropCreateDatabaseAlways<BlogDbContext>
    {
        protected override void Seed(BlogDbContext db)
        {
            Tag blog1 = new Tag("Blog");
            Tag blog2 = new Tag("Science");
            Tag blog3 = new Tag("Energy");
            Tag blog4 = new Tag("Alternative");
            db.Tags.Add(blog1);
            db.Tags.Add(blog2);
            db.Tags.Add(blog3);
            db.Tags.Add(blog4);
            Comment first = new Comment { CommentId = 3, CommentText = "Just a comment on topic", AuthorName = "Sasha", PostedDate = DateTime.Now };
            Comment second = new Comment { CommentId = 4, CommentText = "Just another comment on topic", AuthorName = "Pavel", PostedDate = DateTime.Now };
            TopicComment comm1 = new TopicComment {  Comment = first };
            TopicComment comm2 = new TopicComment {  Comment = second };
            db.Comments.Add(new Comment { CommentId = 1, CommentText = "This is my point on stuff", AuthorName = "Vanya", PostedDate = DateTime.Now, isGuestEntry = true});
            db.Comments.Add(new Comment { CommentId = 2, CommentText = "Nothing valuable...", AuthorName = "Sergey", PostedDate = DateTime.Now, isGuestEntry = true});
            db.Topics.Add(new Topic { TopicId = 1, Title = "The first and the best!",   Tags = new List<Tag>() { blog1 }, Content = "This is my first post. The world is great!", PublishDate = DateTime.Now });
            db.Topics.Add(new Topic { TopicId = 2, Title = "Large Hadron Collider",     Tags = new List<Tag>() { blog1, blog2, blog4 }, Content = "The Large Hadron Collider (LHC) is the world's largest and most powerful particle collider, built by the European Organization for Nuclear Research (CERN) from 1998 to 2008. Its aim is to allow physicists to test the predictions of different theories of particle physics and high-energy physics, and particularly prove or disprove the existence of the theorized Higgs particle[1] and of the large family of new particles predicted by supersymmetric theories.[2] The Higgs particle was confirmed by data from the LHC in 2013. The LHC is expected to address some of the unsolved questions of physics, advancing human understanding of physical laws. It contains seven detectors, each designed for certain kinds of research. The LHC was built in collaboration with over 10,000 scientists and engineers from over 100 countries, as well as hundreds of universities and laboratories.[3] It lies in a tunnel 27 kilometres (17 mi) in circumference, as deep as 175 metres (574 ft) beneath the Franco-Swiss border near Geneva, Switzerland. As of 2014, the LHC remains one of the largest and most complex experimental facilities ever built. Its synchrotron is designed to initially collide two opposing particle beams of either protons at up to 7 teraelectronvolts (7 TeV or 1.12 microjoules) per nucleon, or lead nuclei at an energy of 574 TeV (92.0 µJ) per nucleus (2.76 TeV per nucleon-pair),[4][5] with energies to be doubled to around 14 TeV collision energy—more than seven times any predecessor collider—by around 2015. Collision data were also anticipated to be produced at an unprecedented rate of tens of petabytes per year, to be analysed by a grid-based computer network infrastructure connecting 140 computing centers in 35 countries[6][7] (by 2012 the LHC Computing Grid was the world's largest computing grid, comprising over 170 computing facilities in a worldwide network across 36 countries[8][9][10]).", PublishDate = DateTime.Now });
            db.Topics.Add(new Topic { TopicId = 3, Title = "Curiosity",                 Tags = new List<Tag>() { blog1, blog2, blog4 }, Content = "Curiosity is a car-sized robotic rover exploring Gale Crater on Mars as part of NASA's Mars Science, Laboratory mission (MSL).[3] Curiosity was launched from Cape Canaveral on November 26, 2011, at 10:02 EST aboard the MSL spacecraft and successfully landed on Aeolis Palus in Gale Crater on Mars on August 6, 2012, 05:17 UTC.[1][7] The Bradbury Landing site[8] was less than 2.4 km (1.5 mi) from the center of the rover's touchdown target after a 563,000,000 km (350,000,000 mi) journey.[11] The rover's goals include: investigation of the Martian climate and geology; assessment of whether the selected field site inside Gale Crater has ever offered environmental conditions favorable for microbial life, including investigation of the role of water; and planetary habitability studies in preparation for future human exploration.[12][13] Curiosity's design will serve as the basis for a planned Mars 2020 rover mission. In December 2012, Curiosity's two-year mission was extended indefinitely.[14] In April and early May 2013, Curiosity went into an autonomous operation mode for approximately 25 days during Earth–Mars solar conjunction. During this time, the rover continued to monitor atmospheric and radiation data, but did not move on the Martian surface.[15][16]", PublishDate = DateTime.Now });
            db.Topics.Add(new Topic { TopicId = 4, Title = "Fusion power",              Tags = new List<Tag>() { blog1, blog2, blog3, blog4 }, Comments = new List<TopicComment>(){ comm1, comm2}, Content = "Fusion power is the energy generated by nuclear fusion processes. In fusion reactions, two light atomic nuclei fuse to form a heavier nucleus (in contrast with fission power). In doing so they release a comparatively large amount of energy arising from the binding energy due to the strong nuclear force which is manifested as an increase in temperature of the reactants. Fusion power is a primary area of research in plasma physics. The term is commonly used to refer to potential commercial production of net usable power from a fusion source, similar to the usage of the term 'steam power'. The leading designs for controlled fusion research use magnetic (tokamak design) or inertial (laser) confinement of a plasma. Both approaches are still under development and are years away from commercial operation in which heat from the fusion reaction is used to operate a steam turbine which drives electrical generators, as in existing fossil fuel and nuclear fission power stations.", PublishDate = DateTime.Now });
           
            db.Votes.Add(new Vote { VoteId = 1, Position = "Yes!!!", Count = 0 });
            db.Votes.Add(new Vote { VoteId = 2, Position = "Not really", Count = 0 });

            base.Seed(db);
        }
    }
}