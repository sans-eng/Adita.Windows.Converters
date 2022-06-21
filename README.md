# Adita.Windows.Converters
A .Net WPF converters

## How to use?

to use as application resource, just merge the Converters.xaml that located on root project directory to your app.xaml:
```
 <ResourceDictionary>
    <ResourceDictionary.MergedDictionaries>
        <!--Your code-->
        <!--Your code-->
        
        <!--Merge converters on current project-->
        <ResourceDictionary Source="pack://application:,,,/Adita.Windows.Converters;component/Converters.xaml" />
    </ResourceDictionary.MergedDictionaries>
</ResourceDictionary>
```
