
using AppMAUIGallery.Models;
using AppMAUIGallery.Views.Cells;
using AppMAUIGallery.Views.Components.Forms;
using AppMAUIGallery.Views.Components.Mains;
using AppMAUIGallery.Views.Components.Visuals;
using AppMAUIGallery.Views.Layouts;
using AppMAUIGallery.Views.Lists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMAUIGallery.Repositories
{
    internal class CategoryRepository
    {
        public CategoryRepository() { }
        public List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();
            categories.Add(new Category
            {
                Name = "Layout",
                Components = new List<Component> {
                    new Component { Title = "StackLayout",
                    Description = "Organização sequencial dos elementos.",
                    Page = typeof(StackLayoutPage) },

                    new Component { Title = "Grid",
                    Description = "Organiza os elementos dentro de uma tabela.",
                    Page = typeof(GridLayoutPage) },

                      new Component { Title = "AbsolutLayout",
                    Description = "Libertade total para posicionar e dimensionar os elementos na tela.",
                    Page = typeof(AbsoluteLayoutPage) },

                       new Component { Title = "FlexLayout",
                    Description = "Organiza os elementos de forma sequencial e possui com muitas opções de personalização.",
                    Page = typeof(FlexLayoutPage) }
                },
            });
            categories.Add(new Category
            {
                Name = "Componentes (Views)",
                Components = new List<Component> {
                    new Component { Title = "BoxView",
                    Description = "Um componente que cria uma caixa para ser apresentada",
                    Page = typeof(BoxViewPage)
                    },
                new Component
                {
                    Title = "Label",
                    Description = "Apresenta um texto na tela",
                    Page = typeof(LabelPage)
                },
                 new Component
                {
                    Title = "Button",
                    Description = "Apresenta um botão na tela",
                    Page = typeof(ButtonPage)
                },
                  new Component
                {
                    Title = "Image",
                    Description = "Apresenta uma imagem na tela",
                    Page = typeof(ImagePage)
                },
                     new Component
                {
                    Title = "ImageButton",
                    Description = "Apresenta uma imagem com comportamento de botão",
                    Page = typeof(ImageButtonPage)
                }
            },
            });
            categories.Add(new Category
            {
                Name = "Visuais",
                Components = new List<Component> {
                    new Component { Title = "Frame",
                    Description = "Caixa que envolve outros elementos",
                    Page = typeof(FramePage)
                    
                    },
                    new Component { Title = "Border",
                    Description = "Caixa que envolve outros elementos",
                    Page = typeof(BorderPage)
                    },
                    new Component { Title = "Shadow",
                    Description = "Adiciona uma sombra ao elemento",
                    Page = typeof(ShadowPage)
                    },
            },
            });
            categories.Add(new Category
            {
                Name = "Formulários",
                Components = new List<Component> {
                    new Component { Title = "Entry",
                    Description = "Cria uma caixa de entrada de texto",
                    Page = typeof(EntryPage)
                    },
                    new Component { Title = "Editor",
                    Description = "Cria uma caixa de texto de multiplas linhas",
                    Page = typeof(EditorPage)
                    },
                    new Component { Title = "CheckBox",
                    Description = "Criar caixa de marcação.",
                    Page = typeof(CheckBoxPage)
                    },
                    new Component { Title = "RadioButton",
                    Description = "Criar caixa de marcação de única escolha.",
                    Page = typeof(RadioButtonPage)
                    },
                    new Component { Title = "RadioButton",
                    Description = "Criar caixa de marcação de única escolha.",
                    Page = typeof(RadioButtonPage)
                    },
                    new Component { Title = "Switch",
                    Description = "Caixa de marcação booleana",
                    Page = typeof(SwitchPage)
                    },
                    new Component { Title = "Stepper",
                    Description = "Cria opções de incrementa ou decremeta um numero.",
                    Page = typeof(StepperPage)
                    },
                    new Component { Title = "Slider",
                    Description = "Cria barra que incrementa ou decrementa um numero.",
                    Page = typeof(SliderPage)
                    },
                    new Component { Title = "TimePicker",
                    Description = "Seleção da hora e minuto.",
                    Page = typeof(TimePickerPage)
                    },
                    new Component { Title = "DatePicker",
                    Description = "Seleção de data",
                    Page = typeof(DatePickerPage)
                    },
                    new Component { Title = "Search",
                    Description = "Entrada de campo de texto para pesquisa",
                    Page = typeof(SearchBarPage)
                    },
                    new Component { Title = "Picker",
                    Description = "Selecionar um item da lista.",
                    Page = typeof(PickerPage)
                    },

            },
            });
            categories.Add(new Category
            {
                Name = "Células",
                Components = new List<Component> {
                    new Component { Title = "TextCell",
                    Description = "Apresenta duas labels onde uma é destinada ao titulo e a outra a descrição",
                    Page = typeof(TextCellPage)
                    },
                     new Component { Title = "ImageCell",
                    Description = "Apresenta uma Imagem duas labels onde uma é destinada ao titulo e a outra a descrição",
                    Page = typeof(ImageCellPage)
                    },
                      new Component { Title = "SwitchCell",
                    Description = "Apresenta uma Label em conjunto com o switch",
                    Page = typeof(SwitchCellPage)
                    }, 
                       new Component { Title = "EntryCell",
                    Description = "Apresenta uma Label em conjunto com um entry (Campo de texto).",
                    Page = typeof(EntryCellPage)
                    },
                       new Component { Title = "ViewCellPage",
                    Description = "Permite criar uma celula com layout personalizado.",
                    Page = typeof(ViewCellPage)
                    },
                }
            });
            categories.Add(new Category
            {
                Name = "Listas e Coleções",
                Components = new List<Component> {
                    new Component { Title = "TableView",
                    Description = "Apresenta Celulas em linhas separadas e permite agrupar por seção",
                    Page = typeof(TableViewPage)
                    },
                }
            });

            return categories;
        }
    }
}
