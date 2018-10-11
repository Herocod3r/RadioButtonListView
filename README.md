# RadioButtonListView


A simple bindable radio button listview for xamarin forms


#### Get it on nuget [here](https://www.nuget.org/packages/RadioButtonListView/)

### Use it like so...

```xml

      <ctrl:RadioButtonListView CircleColor="Gray" SelectedColor="Red" HasUnevenRows="true">
                <ctrl:RadioButtonListView.ItemsSource>
                    <x:Array Type="{x:Type sys:String}" x:Key="array">
                        <x:String>Hello</x:String>
                        <x:String>World</x:String>
                    </x:Array>
                </ctrl:RadioButtonListView.ItemsSource>
                
                <ctrl:RadioButtonListView.ItemTemplate>
                    <DataTemplate>
                        
                        <ctrl:RadioButtonViewCell Padding="0" BackgroundColor="WhiteSmoke"> 
                             <StackLayout Padding="10" >
                                     <Label Text="Hello" />
                            <Label Text="World" />
                              </StackLayout>
                        </ctrl:RadioButtonViewCell>
                        
                      
                    </DataTemplate>
                </ctrl:RadioButtonListView.ItemTemplate>
```

