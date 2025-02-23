﻿using Business.Models;
using Business.Services;

namespace ProjectConsoleApp.Dialogs;

public class MainMenuDialog(ProjectService projectService)
{
    private readonly ProjectService _projectService = projectService;

    public async Task ShowMainMenu()
    {
        // Main Menu
        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("=== Project Management Console ===");
            Console.WriteLine("1. View All Projects");
            Console.WriteLine("2. Create New Project");
            Console.WriteLine("3. Edit Existing Project");
            Console.WriteLine("4. Delete Project");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    await DisplayProjects();
                    break;
                case "2":
                    await CreateNewProject();
                    break;
                case "3":
                    await EditProject();
                    break;
                case "4":
                    await DeleteProject();
                    break;
                case "5":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option, press any key to try again...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private async Task DisplayProjects()
    {
        var projects = await _projectService.GetProjectsAsync();
        Console.Clear();
        Console.WriteLine("=== Project List ===");

        if (!projects.Any())
        {
            Console.WriteLine("No projects exist.");
        }
        else
        {
            foreach (ProjectModel project in projects)
            {
                Console.WriteLine($"Name: {project.Title}");
                Console.WriteLine($"Timeframe: {project.StartDate.ToShortDateString()} - {project.EndDate.ToShortDateString()}");
                Console.WriteLine($"Manager: {project.UserName}");
                Console.WriteLine($"Client: {project.CustomerName}");
                Console.WriteLine($"Service: {project.ProductName} - {project.ServicePricePerHour} kr/hour");
                Console.WriteLine($"Total Price: {project.TotalPrice} kr");
                Console.WriteLine($"Status: {project.Status}");
                Console.WriteLine(new string('-', 40));
            }
        }

        Console.WriteLine("Press any key to return to the main menu...");
        Console.ReadKey();
    }

    private async Task CreateNewProject()
    {
        Console.Clear();
        Console.WriteLine("=== Create New Project ===");

        var form = new ProjectRegistration();
        Console.Write("Project Title: ");
        form.Title = Console.ReadLine()!;

        Console.Write("Description: ");
        form.Description = Console.ReadLine()!;

        Console.Write("Start Date (yyyy-mm-dd): ");
        form.StartDate = DateTime.Parse(Console.ReadLine()!);

        Console.Write("End Date (yyyy-mm-dd): ");
        form.EndDate = DateTime.Parse(Console.ReadLine()!);

        //Console.Write("Status ID: ");
        //form.StatusId = int.Parse(Console.ReadLine()!);

        //Console.Write("Project Manager (User ID): ");
        //form.UserId = int.Parse(Console.ReadLine()!);

        //Console.Write("Product (Service ID): ");
        //form.ProductId = int.Parse(Console.ReadLine()!);

        //Console.Write("Service Price Per Hour: ");
        //form.ServicePricePerHour = decimal.Parse(Console.ReadLine()!);

        await _projectService.CreateProjectAsync(form);

        Console.WriteLine("Project created successfully! Press any key to continue...");
        Console.ReadKey();
    }

    // ✅ Updated Method for Proper Null Handling
    private async Task EditProject()
    {
        Console.Clear();
        Console.WriteLine("=== Edit Project ===");
        Console.Write("Enter Project ID to edit: ");
        string? input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input) || !int.TryParse(input, out int projectId))
        {
            Console.WriteLine("Invalid project ID. Press any key to return...");
            Console.ReadKey();
            return;
        }

        ProjectModel? project = await _projectService.GetProjectByIdAsync(projectId);
        if (project == null)
        {
            Console.WriteLine("Project not found. Press any key to return...");
            Console.ReadKey();
            return;
        }

        Console.WriteLine($"Editing Project: {project.Title}");

        Console.Write("New Title (Leave blank to keep current): ");
        string? title = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(title)) project.Title = title;

        Console.Write("New Description (Leave blank to keep current): ");
        string? description = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(description)) project.Description = description;

        Console.Write("New Status ID (Leave blank to keep current): ");
        string? statusInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(statusInput) && int.TryParse(statusInput, out int statusId))
        {
            project.StatusId = statusId;
        }

        await _projectService.UpdateProjectAsync(project);
        Console.WriteLine("Project updated successfully! Press any key to continue...");
        Console.ReadKey();
    }


    private async Task DeleteProject()
    {
        Console.Clear();
        Console.WriteLine("=== Delete Project ===");
        Console.Write("Enter Project ID to delete: ");
        int projectId = int.Parse(Console.ReadLine()!);

        bool success = await _projectService.DeleteProjectAsync(projectId);
        if (success)
            Console.WriteLine("Project deleted successfully.");
        else
            Console.WriteLine("Project not found.");

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}

