using Microsoft.AspNetCore.Mvc;

namespace SealGame.Models.Seals
{
    public class SealCreateViewModel
    {
        public string? Name { get; set; }
        public int SpeciesId { get; set; }

        public int Happiness { get; set; }
        public int Hunger { get; set; }
        public int Enrichment { get; set; }
        public int Cleanliness { get; set; }
        //db
        public DateTime? SealCreated { get; set; }

        public List<IFormFile>? Files { get; set; }
        public List<SealImageViewModel> Image { get; set; } = new List<SealImageViewModel>();


    }
}

/*@model SealGame.ViewModels.SealImageViewModel

@{
    ViewData["Title"] = "Create New Seal";
}

<h1>Create New Seal</h1>

<form asp-action="Create" enctype="multipart/form-data" method="post">
    <div class="form-group">
        <label asp-for="Name" class="control-label"></label>
        <input asp-for="Name" class="form-control" />
        <span asp-validation-for="Name" class="text-danger"></span>
    </div>
    <div class="form-group">
        <label asp-for="SpeciesId" class="control-label">Species</label>
        <select asp-for="SpeciesId" asp-items="ViewBag.SpeciesList" class="form-control"></select>
        <span asp-validation-for="SpeciesId" class="text-danger"></span>
    </div>
    <div class="form-group">
        <label for="ImageFile">Upload Image</label>
        <input type="file" name="ImageFile" class="form-control-file" />
    </div>
    <button type="submit" class="btn btn-primary">Create</button>
</form>

<a asp-action="Index" class="btn btn-secondary">Back to List</a>*/