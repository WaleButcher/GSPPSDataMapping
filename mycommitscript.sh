#!/bin/bash
#get commit message
set /p git_command="Enter commit message: "

#clear repository
git rm -r --cached .

#re-add everything
git add .

#commit new information
git commit -m %git_command%

#push new information
git push

#other commands