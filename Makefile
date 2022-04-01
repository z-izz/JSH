CSC=dotnet

target=ubuntu.20.04-x64
bin=bin/Debug/net6.0/$(target)/JSH
CSC_flags=--runtime $(target) --self-contained

build:
	$(CSC) restore
	$(CSC) build $(CSC_flags)

run:
	./$(bin)
