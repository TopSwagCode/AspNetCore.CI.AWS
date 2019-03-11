# TopSwagCode.CI.AWS

How to implement CI (Continuous Integration)  on AWS. The sample project consists of:

* ASPNET Core WebAPI
* Unit tests

To get your CI up and running on AWS, you need to setup CodeBuild and CodePipeline. CodeBuild is their offering for building your code. CodePipeline is their offering for creating a pipeline / workflow. We will be using the CodePipeline to trigger when there is a new commit on the Github repository.

Start of by creating a new CodeBuild projects

![CodeBuild](/Docs/CodeBuild-1.png)

I will be naming my project TopSwagCode_CI_AWS and enable build badge. (I like a nice badge on my repository). I will be connecting to my github using Oauth, so AWS can fetch my code.

![CodeBuild](/Docs/CodeBuild-2.png)

With github connected, you can now add your repository you want to build.

![CodeBuild](/Docs/CodeBuild-3.png)

Now it is time to setup build enviroment. As of time of writing this guide AWS has "Managed image" for building Dotnet core 2.1. But since my sample project is using Dotnet core 2.2 I will be using a custom build image. I found the docker image I needed [here.](https://hub.docker.com/_/microsoft-dotnet-core)

![CodeBuild](/Docs/CodeBuild-4.png)

Buildspec is how you describe your build process. Picking "Insert build commands" will give you a sample build, which can be edited for your process. I have just added simple build and test for my dotnet core project.

![CodeBuild](/Docs/CodeBuild-5.png)

For my project I will not be using any kind of logging. It would be a good idea to add it to your project. This will enable to you see what is failing.

That's all for CodeBuild. Now you can start building your code on AWS. Only problem is you have to run your builds manually. Which brings us to the next part.

![CodeBuild](/Docs/CodeBuild-6.png)

Now it's time to create your CodePipeline.

![CodeBuild](/Docs/CodePipeline-1.png)

CodePipeline consists of 3 steps. I will skip CodeDeploy for this guide.

![CodeBuild](/Docs/CodePipeline-2.png)

Once again you need to pick your github repository.

![CodeBuild](/Docs/CodePipeline-3.png)

Next step is for how you want your code build. Pick AWS CodeBuild and pick the CodeBuild we created just a few moments ago.

![CodeBuild](/Docs/CodePipeline-4.png)

Here is the deploy step. I will be skipping it for this guide.

![CodeBuild](/Docs/CodePipeline-5.png)

Now your done. AWS will start your pipeline to see everything is setup right. After few minutes your build should be done and thats it.

![CodeBuild](/Docs/CodePipeline-6.png)

You can see history of your build on the CodeBuild page. Below you can see a build that failed on unit test and one where I had fixed it.

![CodeBuild](/Docs/CodeBuild-7.png)

You now have CI up and running on AWS. You can always improve your setup by saving the test results. Perhaps run some codecoverage tool or whatever you can think of.