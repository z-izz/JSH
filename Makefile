CSC=dotnet

target=linux-x64
bin=bin/Debug/net6.0/$(target)/JSH
CSC_flags=--runtime $(target) --self-contained --no-restore

build:
	$(CSC) restore
	$(CSC) build $(CSC_flags)

run:
	./$(bin)
