#!/bin/bash
#get commit message
read -p "Enter commit message: " git_command

#clear repository
git rm -r --cached .

#re-add everything
git add .

#commit new information
git commit -m "$git_command"

#push new information
git push

#other commands