# JSH
A Command-Line Shell.

This Branch Is The `linux` branch.

There are no plans of making a version of JSH for windows.

# Limitations
1. `|` is not recongnized yet, so `ls / | grep home` wouldn't work.
2. no concept of scripting, use `bash` for that.
3. no concept of `HOME` key.
4. no command history.

# Differences
1. `cd ..` is `cd..`
1. `cls` is a refrence to `clear`

# Building
You **can** build on windows, using visual studio.

But it is designed to be built on linux.

this is how to build JSH on linux:

1. Open A Terminal.
2. Install `dotnet-sdk`.
3. If `git` is not installed yet, install it.
4. To get the source, type `git clone https://www.github.com/Gordae/JSH --branch linux`
5. `cd` into the JSH folder that git cloned into.
6. If `make` is not installed yet, install it.
7. To compile, type `make build`
8. To test your output, type `make run`
