# PawnMapTranslator

Converts Pawn map filterscripts into C# `MapDefinition` classes for `SampSharp.MapObjects`.

## Usage

Place one or more Pawn map filterscripts (`.pwn`) in:
```
bin/Debug/net10.0/maps
```

For example:
```
bin/Debug/net10.0/maps/
├── Aim_Headshot.pwn
├── Area51.pwn
└── de_dust2.pwn
```

Run the translator.

The generated C# files will be written to:
```
bin/Debug/net10.0/generated
```

For example:
```
bin/Debug/net10.0/generated/
├── Aim_Headshot.cs
├── Area51.cs
└── de_dust2.cs
```

## Supported Pawn functions

The translator currently recognizes:
- `CreateObject`
- `SetObjectMaterial`

After generating the initial `MapDefinition` class, you can further customize it using regular C# code.