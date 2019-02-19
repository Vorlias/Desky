# Desky
A simple CLI tool to set individual monitor wallpapers in Windows 10.

I created this a while back, because the way to achieve setting multiple wallpapers in Windows 10 is very tedious.


## Usage
If you have two monitors, the first argument will be monitor 1, the second monitor 2.

### desky -a|--use-args
`desky -a "path\to\wallpaper1.jpg" "path\to\wallpaper2.jpg" ...` (add more, if there's more monitors)

### desky -f|--file=
`desky -f wallpaper-config.txt`
Where wallpaper-config.txt is such:
```
path\to\wallpaper1.jpg
path\to\wallpaper2.jpg
```

### desky -m|--make
`desky --make`
Will allow you to select wallpapers for each monitor, then save the config file to use with `desky -f`
