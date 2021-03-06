**1.14.0.0**
- Fix #8: Hang at runtime if generic class uses property info in interceptor

**1.13.0.0**
- Fine-tune #6 to support get-only properties.

**1.12.0.0**
- Fix #6: Set interceptor is not invoked by auto property initializer

**1.11.0.0**
- Fix #7: AmbiguousMatchException when subclass hides an inherited property of different type

**1.10.0.0**
- Fix #5: Update to use Fody3

**1.9.0.0**
- Fix #4: Support NetStandard projects

**1.8.0.0**
- Fix #3: Invalid code generated when SetBackingField contains any conditions

**1.7.0.0**
- Fix #2: Support generics and private/explicit implemented properties

**1.6.0.0**
- Seal attributes to avoid CA warnings in target module

**1.5.0.0**
- Preserve interceptor attributes locally to enable inheritance across modules

**1.4.0.0**
- Add more logging
- Support ref/out values
- Add validation of interceptor return types

**1.3.0.0**
- Fix possible exception in SetBackingField for empty properties

**1.2.0.0**
- Add auto-property interceptor

**1.1.0.0**
- Fix #1: Handle complex parameters

**1.0.0.0**
- Add support for .Net 4.0 projects

**0.9.1.0**
- Initial release
