using MauiReactor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4.Pages
{
    internal class MainPageState
    {
        public bool IsExpanded_Green { get; set; }
        public bool IsExpanded_Red { get; set; }
        public int Status { get; set; }
    }

    internal class MainPage : Component<MainPageState>
    {
        public override VisualNode Render()
        {
            SetState(s => s.Status++);
            return new ContentPage
            {
                new Grid("auto,auto,auto,auto", "*,*")
                {
                    new Label("Tap on each box").GridColumn(0).GridRow(0).GridColumnSpan(2).VCenter().HCenter(),

                    new Label("Works --> invalidateComponent TRUE").GridColumn(0).GridRow(1).VCenter().HCenter(),
                    new BoxView().GridColumn(0).GridRow(2)
                        .HeightRequest(80).WidthRequest(80)
                        .Color(Colors.Green)
                        .Opacity(State.IsExpanded_Green ? 1 : 0.2)
                        .HeightRequest(State.IsExpanded_Green ? 250 : 80)
                        .WithAnimation(easing: Easing.Linear, duration: 1000)
                        .OnTapped(() =>{
                            SetState(s => s.IsExpanded_Green = !s.IsExpanded_Green);
                        }),

                    new Label("Doesn't works --> invalidateComponent FALSE").GridColumn(1).GridRow(1).VCenter().HCenter(),
                    new BoxView().GridColumn(1).GridRow(2)
                        .HeightRequest(80).WidthRequest(80)
                        .Color(Colors.Red)
                        .Opacity(() => State.IsExpanded_Red ? 1 : 0.2)
                        .HeightRequest(() => State.IsExpanded_Red ? 250 : 80)
                        .WithAnimation(easing: Easing.Linear, duration: 1000)
                        .OnTapped(() =>{
                            SetState(s => s.IsExpanded_Red = !s.IsExpanded_Red, false);
                        }),
                    new Label($"Render called {State.Status}").GridColumn(0).GridRow(3).GridColumnSpan(2).VCenter().HCenter()
                }
                .VCenter().HCenter()
                .RowSpacing(25).ColumnSpacing(25)
                .Padding(30, 0)
            };
        }
    }
}