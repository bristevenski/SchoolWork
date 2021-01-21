# This is the main for Prog1.
# It invokes the run method of a Vectorator instance
# Author:: Dr. Clifton, modified by Dr. Tian

require_relative 'Vectorator'

# If you want to read from a file for testing, uncomment this line
# and put a p1.in
# file in the folder of your project (with your source files).
# This redirects Standard Input to come from a file.

#$stdin.reopen("p1.in")

# Make a Vectorator instance and invoke its run method
Vectorator.new.run
