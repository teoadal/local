# Marble

[![.NET Core](https://github.com/teoadal/local/workflows/.NET%20Core/badge.svg?branch=master)](https://github.com/teoadal/local/actions)
[![codecov](https://codecov.io/gh/teoadal/local/branch/master/graph/badge.svg)](https://codecov.io/gh/teoadal/local)
[![NuGet](https://img.shields.io/nuget/v/locals.svg)](https://www.nuget.org/packages/locals) 
[![NuGet](https://img.shields.io/nuget/dt/locals.svg)](https://www.nuget.org/packages/locals)

Simple collection on stack. 
Use to store a small number of items without allocating an intermediate collection.

## Performance

## Install from nuget

Install Marble with the following command [from nuget](https://www.nuget.org/packages/locals/):

```ini
Install-Package Locals
```

## Usage

```cs
var vector = new LocalVector<Foo>();
vector.Add(new Foo { Value = 1 });
vector.AddRange(items);

return vector
    .Where((item, arg) => item.Value > arg, argument)
    .OrderBy(item => item.Value)
    .Select(item => item.Value)
    .Max();
```
