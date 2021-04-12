# Locals

[![.NET Core](https://github.com/teoadal/local/workflows/.NET%20Core/badge.svg?branch=master)](https://github.com/teoadal/local/actions)
[![codecov](https://codecov.io/gh/teoadal/local/branch/master/graph/badge.svg)](https://codecov.io/gh/teoadal/local)
[![NuGet](https://img.shields.io/nuget/v/locals.svg)](https://www.nuget.org/packages/locals) 
[![NuGet](https://img.shields.io/nuget/dt/locals.svg)](https://www.nuget.org/packages/locals)

Simple collection on stack. 
Use to store a small number of items (up to 7) without allocating an intermediate collection.

## Performance

#### Enumerable without allocation

|      Method | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------ |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|        List |     5 |  75.42 ns | 0.523 ns | 0.437 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      96 B |
| **LocalVector** |     5 |  63.55 ns | 0.369 ns | 0.327 ns |  **0.84** |    0.01 |      - |     - |     - |         - |
|             |       |           |          |          |       |         |        |       |       |           |
|        List |     7 |  85.89 ns | 1.578 ns | 1.938 ns |  1.00 |    0.00 | 0.0178 |     - |     - |     112 B |
| **LocalVector** |     7 |  77.24 ns | 0.332 ns | 0.310 ns |  **0.90** |    0.02 |      - |     - |     - |         - |
|             |       |           |          |          |       |         |        |       |       |           |
|        List |    10 |  96.96 ns | 0.827 ns | 0.691 ns |  1.00 |    0.00 | 0.0216 |     - |     - |     136 B |
| **LocalVector** |    10 | 108.74 ns | 0.633 ns | 0.561 ns |  **1.12** |    0.01 | 0.0076 |     - |     - |      48 B |

#### Execute linq-like operations

|      Method | Count |      Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------ |------ |----------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|        List |     5 |  76.99 ns | 0.880 ns | 0.823 ns |  1.00 | 0.0153 |     - |     - |      96 B |
| **LocalVector** |     5 |  63.75 ns | 0.451 ns | 0.376 ns |  **0.83** |      - |     - |     - |         - |
|             |       |           |          |          |       |        |       |       |           |
|        List |     7 |  84.01 ns | 0.833 ns | 0.739 ns |  1.00 | 0.0178 |     - |     - |     112 B |
| **LocalVector** |     7 |  77.07 ns | 0.309 ns | 0.289 ns |  **0.92** |      - |     - |     - |         - |
|             |       |           |          |          |       |        |       |       |           |
|        List |    10 |  93.43 ns | 0.513 ns | 0.455 ns |  1.00 | 0.0216 |     - |     - |     136 B |
| **LocalVector** |    10 | 107.94 ns | 0.424 ns | 0.376 ns |  **1.16** | 0.0076 |     - |     - |      48 B |


## Install from nuget

Install Locals with the following command [from nuget](https://www.nuget.org/packages/locals/):

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
