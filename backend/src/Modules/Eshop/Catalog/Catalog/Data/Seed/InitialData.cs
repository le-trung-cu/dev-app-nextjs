using System;
using Catalog.Categories.Models;

namespace Catalog.Data.Seed;

public class InitialData
{
  public static List<Category> Categories =>  [
      new Category {
      Name= "All",
      Slug= "all",
    },
    new Category{
      Name= "Business & Money",
      Color= "#FFB347",
      Slug= "business-money",
      Subcategories= [
        new Category { Name= "Accounting", Slug= "accounting" },
        new Category {
          Name= "Entrepreneurship",
          Slug= "entrepreneurship",
        },
        new Category { Name= "Gigs & Side Projects", Slug= "gigs-side-projects" },
        new Category { Name= "Investing", Slug= "investing" },
        new Category { Name= "Management & Leadership", Slug= "management-leadership" },
        new Category {
          Name= "Marketing & Sales",
          Slug= "marketing-sales",
        },
        new Category { Name= "Networking, Careers & Jobs", Slug= "networking-careers-jobs" },
        new Category { Name= "Personal Finance", Slug= "personal-finance" },
        new Category { Name= "Real Estate", Slug= "real-estate" },
      ],
    },
    new Category {
      Name= "Software Development",
      Color= "#7EC8E3",
      Slug= "software-development",
      Subcategories= [
        new Category{ Name= "Web Development", Slug= "web-development" },
        new Category { Name= "Mobile Development", Slug= "mobile-development" },
        new Category { Name= "Game Development", Slug= "game-development" },
        new Category { Name= "Programming Languages", Slug= "programming-languages" },
        new Category { Name= "DevOps", Slug= "devops" },
      ],
    },
    new Category {
      Name= "Writing & Publishing",
      Color= "#D8B5FF",
      Slug= "writing-publishing",
      Subcategories= [
        new Category { Name= "Fiction", Slug= "fiction" },
        new Category { Name= "Non-Fiction", Slug= "non-fiction" },
        new Category { Name= "Blogging", Slug= "blogging" },
        new Category { Name= "Copywriting", Slug= "copywriting" },
        new Category { Name= "Self-Publishing", Slug= "self-publishing" },
      ],
    },
    new Category {
      Name= "Other",
      Slug= "other",
    },
    new Category {
      Name= "Education",
      Color= "#FFE066",
      Slug= "education",
      Subcategories= [
        new Category { Name= "Online Courses", Slug= "online-courses" },
        new Category { Name= "Tutoring", Slug= "tutoring" },
        new Category { Name= "Test Preparation", Slug= "test-preparation" },
        new Category { Name= "Language Learning", Slug= "language-learning" },
      ],
    },
    new Category {
      Name= "Self Improvement",
      Color= "#96E6B3",
      Slug= "self-improvement",
      Subcategories= [
        new Category { Name= "Productivity", Slug= "productivity" },
        new Category { Name= "Personal Development", Slug= "personal-development" },
        new Category { Name= "Mindfulness", Slug= "mindfulness" },
        new Category { Name= "Career Growth", Slug= "career-growth" },
      ],
    },
    new Category {
      Name= "Fitness & Health",
      Color= "#FF9AA2",
      Slug= "fitness-health",
      Subcategories= [
        new Category { Name= "Workout Plans", Slug= "workout-plans" },
        new Category { Name= "Nutrition", Slug= "nutrition" },
        new Category { Name= "Mental Health", Slug= "mental-health" },
        new Category { Name= "Yoga", Slug= "yoga" },
      ],
    },
    new Category {
      Name= "Design",
      Color= "#B5B9FF",
      Slug= "design",
      Subcategories= [
        new Category { Name= "UI/UX", Slug= "ui-ux" },
        new Category { Name= "Graphic Design", Slug= "graphic-design" },
        new Category { Name= "3D Modeling", Slug= "3d-modeling" },
        new Category { Name= "Typography", Slug= "typography" },
      ],
    },
    new Category{
      Name= "Drawing & Painting",
      Color= "#FFCAB0",
      Slug= "drawing-painting",
      Subcategories= [
        new Category { Name= "Watercolor", Slug= "watercolor" },
        new Category { Name= "Acrylic", Slug= "acrylic" },
        new Category { Name= "Oil", Slug= "oil" },
        new Category { Name= "Pastel", Slug= "pastel" },
        new Category { Name= "Charcoal", Slug= "charcoal" },
      ],
    },
    new Category{
      Name= "Music",
      Color= "#FFD700",
      Slug= "music",
      Subcategories= [
        new Category{ Name= "Songwriting", Slug= "songwriting" },
        new Category{ Name= "Music Production", Slug= "music-production" },
        new Category{ Name= "Music Theory", Slug= "music-theory" },
        new Category{ Name= "Music History", Slug= "music-history" },
      ],
    },
    new Category {
      Name= "Photography",
      Color= "#FF6B6B",
      Slug= "photography",
      Subcategories= [
      new Category { Name= "Portrait", Slug= "portrait" },
      new Category { Name= "Landscape", Slug= "landscape" },
      new Category { Name= "Street Photography", Slug= "street-photography" },
      new Category { Name= "Nature", Slug= "nature" },
      new Category { Name= "Macro", Slug= "macro" },
      ],
    },
  ];
}
