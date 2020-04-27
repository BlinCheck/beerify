# Beerify
Rules to run repository:
1. Branch 'dev' should contain current working functionality of the app, don't add unfinished work in it. Also don't push anything directly to branch dev.
2. If you want to add new functionality then create new branch for it.
3. When you're ready to add your files to dev, first run 'git rebase dev -i' and fixup all commits but one with message that describes added functionality (this is to keep graph as short and neat as possible). 
Then push your branch to repository (git push origin mybranch -f) and create new pull request to merge your branch in dev.
Finally, merge your feature to branch dev.

P.S.: don't forget to pull dev from time to time to keep your local version of the app updated.
