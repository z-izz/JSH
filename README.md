# JSH
A Command-Line Shell.

This Branch Is The `linux` branch.

Currently, the `windows` branch is not created yet.

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

1. Open A Terminal.
2. Install `dotnet-sdk`.
3. If `git` is not installed yet, install it.
4. To get the source, type `git clone https://www.github.com/Gordae/JSH --branch linux`
5. `cd` into the JSH folder that git cloned into.
6. If `make` is not installed yet, install it.
7. To compile, type `make build`
8. To test your output, type `make run`
