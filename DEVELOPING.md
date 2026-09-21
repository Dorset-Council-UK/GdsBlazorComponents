
# Developing for GDS Blazor Components

Thank you for your interest in contributing to the GDS Blazor Components library! This guide will help you set up your development environment and understand the basic components of the project.

## Dependencies

To run GDS Blazor Components with minimal modification, you will need the following:

- **.NET 10**: Ensure you have the .NET 10 SDK installed.
- **GDS Framework**: The project relies on the Government Digital Service (GDS) framework for its front-end.
- **Blazor**: The project which uses these components needs to be setup to use Blazor.

## Getting Started

1. **Clone the repository**:
   ```shell
   git clone <repository-url>
   cd <repository-folder>
   ```

2. **Create a new branch**:
   ```shell
   git checkout -b <branch-name>
   ```

3. **Install front-end dependencies**:

   Run the following command in the root folder:
   ```shell
   npm install
   ```

## Local Development

Libraries can be challenging to develop. We recommend making use of the [`GdsBlazorComponents-Demo`](https://github.com/Dorset-Council-UK/GdsBlazorComponents-Demo) project to test your changes locally.

Here is our current local development loop. Ideas for improvements to this process are welcome.

- Clone the `GdsBlazorComponents-Demo` repository and make sure can run it locally. This will allow you to see your changes in action.
- [Create a new package source](https://learn.microsoft.com/en-us/nuget/consume-packages/nuget-visual-studio-options#sources) on your local machine. Point it at a local folder e.g. `C:\LocalNugetFeed`. This will be used to host your local builds of the `GdsBlazorComponents` package.
- Make some changes to your local copy of the `GdsBlazorComponents` project.
- Up the version number in the `GdsBlazorComponents` project. This is important to ensure that the demo project picks up your changes.
- Publish the `GdsBlazorComponents` project to your local NuGet feed. You can do this by running the following command in the root folder of the `GdsBlazorComponents` project:
  ```shell
  dotnet pack -o <path-to-local-nuget-feed>
  ```
  Or by using the Visual Studio Pack command (Build -> Pack), and copying the output to your local NuGet feed folder.
- Update the `GdsBlazorComponents-Demo` project to use the new version of the `GdsBlazorComponents` package. Make sure your package source is set to your local feed, and your new version should appear as an available update.
- For further changes, repeat the process of making changes, updating the version number, and publishing to your local feed.

You may also be able to remove the NuGet reference altogether and reference the `GdsBlazorComponents` project directly in the demo project. This will allow you to make changes to the library and see them reflected in the demo project without having to publish a new version of the package. However, this approach may not work in all cases, and you may need to revert to using a local NuGet feed if you encounter issues.

When you are done, remember to put your version number back to the original value before committing your changes.

You will also want to run `dotnet nuget locals --clear all` to clear your local NuGet cache when done, to ensure that you don't accidentally pick up a cached version of the package when you are done.

## Further Help

For further help, please reach out to the maintainers or consult the documentation. 
