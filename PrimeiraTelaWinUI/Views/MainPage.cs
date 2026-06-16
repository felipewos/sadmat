using System;
using System.CodeDom.Compiler;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Markup;
using PrimeiraTelaWinUI.Data;
using WinRT;
using WinRT.PrimeiraTelaWinUIVtableClasses;
using Windows.System;

namespace PrimeiraTelaWinUI.Views;

[WinRTRuntimeClassName("Microsoft.UI.Xaml.IUIElementOverrides")]
[WinRTExposedType(typeof(PrimeiraTelaWinUI_Views_ProjectDetailsPageWinRTTypeDetails))]
public class MainPage : Page, IComponentConnector
{
	[GeneratedCode("Microsoft.UI.Xaml.Markup.Compiler", " 3.0.0.2602")]
	private interface IMainPage_Bindings
	{
		void Initialize();

		void Update();

		void StopTracking();

		void DisconnectUnloadedObject(int connectionId);
	}

	private interface IMainPage_BindingsScopeConnector
	{
		WeakReference Parent { get; set; }

		bool ContainsElement(int connectionId);

		void RegisterForElementConnection(int connectionId, IComponentConnector connector);
	}

	[GeneratedCode("Microsoft.UI.Xaml.Markup.Compiler", " 3.0.0.2602")]
	[DebuggerNonUserCode]
	private static class XamlBindingSetters
	{
		public static void Set_Microsoft_UI_Xaml_Controls_TextBlock_Text(TextBlock obj, string value, string targetNullValue)
		{
			if (value == null && targetNullValue != null)
			{
				value = targetNullValue;
			}
			obj.Text = value ?? string.Empty;
		}
	}

	[GeneratedCode("Microsoft.UI.Xaml.Markup.Compiler", " 3.0.0.2602")]
	[DebuggerNonUserCode]
	[WinRTRuntimeClassName("Microsoft.UI.Xaml.IDataTemplateExtension")]
	[WinRTExposedType(typeof(PrimeiraTelaWinUI_Views_ProjectDetailsPage_ProjectDetailsPage_obj30_BindingsWinRTTypeDetails))]
	private class MainPage_obj4_Bindings : IDataTemplateExtension, IDataTemplateComponent, IComponentConnector, IMainPage_Bindings
	{
		[GeneratedCode("Microsoft.UI.Xaml.Markup.Compiler", " 3.0.0.2602")]
		[DebuggerNonUserCode]
		private class MainPage_obj4_BindingsTracking
		{
			private WeakReference<MainPage_obj4_Bindings> weakRefToBindingObj;

			public MainPage_obj4_BindingsTracking(MainPage_obj4_Bindings obj)
			{
				weakRefToBindingObj = new WeakReference<MainPage_obj4_Bindings>(obj);
			}

			public MainPage_obj4_Bindings TryGetBindingObject()
			{
				MainPage_obj4_Bindings bindingObject = null;
				if (weakRefToBindingObj != null)
				{
					weakRefToBindingObj.TryGetTarget(out bindingObject);
					if (bindingObject == null)
					{
						weakRefToBindingObj = null;
						ReleaseAllListeners();
					}
				}
				return bindingObject;
			}

			public void ReleaseAllListeners()
			{
				UpdateChildListeners_(null);
			}

			public void PropertyChanged_(object sender, PropertyChangedEventArgs e)
			{
				MainPage_obj4_Bindings bindings = TryGetBindingObject();
				if (bindings == null)
				{
					return;
				}
				string propName = e.PropertyName;
				ProjectItem obj = sender as ProjectItem;
				if (string.IsNullOrEmpty(propName))
				{
					if (obj != null)
					{
						bindings.Update_Name(obj.Name, 1073741824);
						bindings.Update_Course(obj.Course, 1073741824);
						bindings.Update_CreatedAtText(obj.CreatedAtText, 1073741824);
						bindings.Update_ModifiedAtText(obj.ModifiedAtText, 1073741824);
					}
					return;
				}
				switch (propName)
				{
				case "Name":
					if (obj != null)
					{
						bindings.Update_Name(obj.Name, 1073741824);
					}
					break;
				case "Course":
					if (obj != null)
					{
						bindings.Update_Course(obj.Course, 1073741824);
					}
					break;
				case "CreatedAtText":
					if (obj != null)
					{
						bindings.Update_CreatedAtText(obj.CreatedAtText, 1073741824);
					}
					break;
				case "ModifiedAtText":
					if (obj != null)
					{
						bindings.Update_ModifiedAtText(obj.ModifiedAtText, 1073741824);
					}
					break;
				}
			}

			public void UpdateChildListeners_(ProjectItem obj)
			{
				MainPage_obj4_Bindings bindings = TryGetBindingObject();
				if (bindings != null)
				{
					if (bindings.dataRoot != null)
					{
						((INotifyPropertyChanged)bindings.dataRoot).PropertyChanged -= PropertyChanged_;
					}
					if (obj != null)
					{
						bindings.dataRoot = obj;
						((INotifyPropertyChanged)obj).PropertyChanged += PropertyChanged_;
					}
				}
			}
		}

		private ProjectItem dataRoot;

		private bool initialized;

		private const int NOT_PHASED = int.MinValue;

		private const int DATA_CHANGED = 1073741824;

		private bool removedDataContextHandler;

		private WeakReference obj4;

		private TextBlock obj5;

		private TextBlock obj6;

		private TextBlock obj7;

		private TextBlock obj8;

		private MainPage_obj4_BindingsTracking bindingsTracking;

		public MainPage_obj4_Bindings()
		{
			bindingsTracking = new MainPage_obj4_BindingsTracking(this);
		}

		public void Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 4:
				obj4 = new WeakReference(target.As<Grid>());
				break;
			case 5:
				obj5 = target.As<TextBlock>();
				break;
			case 6:
				obj6 = target.As<TextBlock>();
				break;
			case 7:
				obj7 = target.As<TextBlock>();
				break;
			case 8:
				obj8 = target.As<TextBlock>();
				break;
			}
		}

		[GeneratedCode("Microsoft.UI.Xaml.Markup.Compiler", " 3.0.0.2602")]
		[DebuggerNonUserCode]
		public IComponentConnector GetBindingConnector(int connectionId, object target)
		{
			return null;
		}

		public void DataContextChangedHandler(FrameworkElement sender, DataContextChangedEventArgs args)
		{
			if (SetDataRoot(args.NewValue))
			{
				Update();
			}
		}

		public bool ProcessBinding(uint phase)
		{
			throw new NotImplementedException();
		}

		public int ProcessBindings(ContainerContentChangingEventArgs args)
		{
			int nextPhase = -1;
			ProcessBindings(args.Item, args.ItemIndex, (int)args.Phase, out nextPhase);
			return nextPhase;
		}

		public void ResetTemplate()
		{
			Recycle();
		}

		public void ProcessBindings(object item, int itemIndex, int phase, out int nextPhase)
		{
			nextPhase = -1;
			if (phase == 0)
			{
				nextPhase = -1;
				SetDataRoot(item);
				if (!removedDataContextHandler)
				{
					removedDataContextHandler = true;
					Grid rootElement = obj4.Target as Grid;
					if (rootElement != null)
					{
						rootElement.DataContextChanged -= DataContextChangedHandler;
					}
				}
				initialized = true;
			}
			Update_(item.As<ProjectItem>(), 1 << phase);
		}

		public void Recycle()
		{
			bindingsTracking.ReleaseAllListeners();
		}

		public void Initialize()
		{
			if (!initialized)
			{
				Update();
			}
		}

		public void Update()
		{
			Update_(dataRoot, int.MinValue);
			initialized = true;
		}

		public void StopTracking()
		{
			bindingsTracking.ReleaseAllListeners();
			initialized = false;
		}

		public void DisconnectUnloadedObject(int connectionId)
		{
			throw new ArgumentException("No unloadable elements to disconnect.");
		}

		public bool SetDataRoot(object newDataRoot)
		{
			bindingsTracking.ReleaseAllListeners();
			if (newDataRoot != null)
			{
				dataRoot = newDataRoot.As<ProjectItem>();
				return true;
			}
			return false;
		}

		private void Update_(ProjectItem obj, int phase)
		{
			bindingsTracking.UpdateChildListeners_(obj);
			if (obj != null && (phase & -1073741823) != 0)
			{
				Update_Name(obj.Name, phase);
				Update_Course(obj.Course, phase);
				Update_CreatedAtText(obj.CreatedAtText, phase);
				Update_ModifiedAtText(obj.ModifiedAtText, phase);
			}
		}

		private void Update_Name(string obj, int phase)
		{
			if ((phase & -1073741823) != 0)
			{
				XamlBindingSetters.Set_Microsoft_UI_Xaml_Controls_TextBlock_Text(obj5, obj, null);
			}
		}

		private void Update_Course(string obj, int phase)
		{
			if ((phase & -1073741823) != 0)
			{
				XamlBindingSetters.Set_Microsoft_UI_Xaml_Controls_TextBlock_Text(obj6, obj, null);
			}
		}

		private void Update_CreatedAtText(string obj, int phase)
		{
			if ((phase & -1073741823) != 0)
			{
				XamlBindingSetters.Set_Microsoft_UI_Xaml_Controls_TextBlock_Text(obj7, obj, null);
			}
		}

		private void Update_ModifiedAtText(string obj, int phase)
		{
			if ((phase & -1073741823) != 0)
			{
				XamlBindingSetters.Set_Microsoft_UI_Xaml_Controls_TextBlock_Text(obj8, obj, null);
			}
		}
	}

	private int defaultProjectCounter = 1;

	[GeneratedCode("Microsoft.UI.Xaml.Markup.Compiler", " 3.0.0.2602")]
	private ListView ProjectsListView;

	[GeneratedCode("Microsoft.UI.Xaml.Markup.Compiler", " 3.0.0.2602")]
	private Button OpenButton;

	[GeneratedCode("Microsoft.UI.Xaml.Markup.Compiler", " 3.0.0.2602")]
	private Button RenameButton;

	[GeneratedCode("Microsoft.UI.Xaml.Markup.Compiler", " 3.0.0.2602")]
	private Button DeleteButton;

	[GeneratedCode("Microsoft.UI.Xaml.Markup.Compiler", " 3.0.0.2602")]
	private bool _contentLoaded;

	[GeneratedCode("Microsoft.UI.Xaml.Markup.Compiler", " 3.0.0.2602")]
	private IMainPage_Bindings Bindings;

	private ObservableCollection<ProjectItem> Projects { get; } = new ObservableCollection<ProjectItem>();

	public MainPage()
	{
		InitializeComponent();
		ProjectsListView.ItemsSource = Projects;
		LoadProjects();
		UpdateActionButtons();
	}

	private async void OnCreateClicked(object sender, RoutedEventArgs e)
	{
		string suggestedInstitution = $"Instituição {defaultProjectCounter}";
		string projectName = suggestedInstitution;
		string courseName = string.Empty;
		while (true)
		{
			TextBox institutionTextBox = new TextBox
			{
				Text = projectName,
				PlaceholderText = "Instituição",
				MinWidth = 320.0
			};
			TextBox courseTextBox = new TextBox
			{
				Text = courseName,
				PlaceholderText = "Curso",
				MinWidth = 320.0
			};
			StackPanel contentPanel = new StackPanel
			{
				Spacing = 8.0
			};
			contentPanel.Children.Add(new TextBlock
			{
				Text = "Instituição"
			});
			contentPanel.Children.Add(institutionTextBox);
			contentPanel.Children.Add(new TextBlock
			{
				Text = "Curso"
			});
			contentPanel.Children.Add(courseTextBox);
			if (await new ContentDialog
			{
				Title = "Criar projeto escolar",
				Content = contentPanel,
				PrimaryButtonText = "Criar",
				CloseButtonText = "Cancelar",
				DefaultButton = ContentDialogButton.Primary,
				XamlRoot = base.XamlRoot
			}.ShowAsync() != ContentDialogResult.Primary)
			{
				return;
			}
			projectName = institutionTextBox.Text.Trim();
			courseName = courseTextBox.Text.Trim();
			if (!string.IsNullOrWhiteSpace(projectName) && !string.IsNullOrWhiteSpace(courseName))
			{
				break;
			}
			await ShowMessageAsync("Campos obrigatórios", "Preencha Instituição e Curso para criar o projeto escolar.");
		}
		try
		{
			string folderPath = ProjectStorage.CreateProjectFolder(projectName);
			ProjectItem project = new ProjectItem(projectName, courseName, DateTimeOffset.Now, DateTimeOffset.Now, folderPath);
			Projects.Add(project);
			ProjectsListView.SelectedItem = project;
			SaveProjects();
			defaultProjectCounter = GetNextProjectCounter();
			UpdateActionButtons();
		}
		catch (Exception ex)
		{
			await ShowMessageAsync("Erro ao criar projeto", "Não foi possível criar a pasta do projeto escolar.\n\n" + ex.Message);
		}
	}

	private async void OnOpenClicked(object sender, RoutedEventArgs e)
	{
		await TryOpenSelectedProjectAsync();
	}

	private async void OnRenameClicked(object sender, RoutedEventArgs e)
	{
		object selectedItem = ProjectsListView.SelectedItem;
		if (!(selectedItem is ProjectItem selectedProject))
		{
			return;
		}
		string newProjectName = selectedProject.Name;
		string newCourseName = selectedProject.Course;
		while (true)
		{
			TextBox institutionTextBox = new TextBox
			{
				Text = newProjectName,
				PlaceholderText = "Instituição",
				MinWidth = 320.0
			};
			TextBox courseTextBox = new TextBox
			{
				Text = newCourseName,
				PlaceholderText = "Curso",
				MinWidth = 320.0
			};
			StackPanel contentPanel = new StackPanel
			{
				Spacing = 8.0
			};
			contentPanel.Children.Add(new TextBlock
			{
				Text = "Instituição"
			});
			contentPanel.Children.Add(institutionTextBox);
			contentPanel.Children.Add(new TextBlock
			{
				Text = "Curso"
			});
			contentPanel.Children.Add(courseTextBox);
			if (await new ContentDialog
			{
				Title = "Editar projeto escolar",
				Content = contentPanel,
				PrimaryButtonText = "Salvar",
				CloseButtonText = "Cancelar",
				DefaultButton = ContentDialogButton.Primary,
				XamlRoot = base.XamlRoot
			}.ShowAsync() != ContentDialogResult.Primary)
			{
				return;
			}
			newProjectName = institutionTextBox.Text.Trim();
			newCourseName = courseTextBox.Text.Trim();
			if (!string.IsNullOrWhiteSpace(newProjectName) && !string.IsNullOrWhiteSpace(newCourseName))
			{
				break;
			}
			await ShowMessageAsync("Campos obrigatórios", "Preencha Instituição e Curso para salvar o projeto escolar.");
		}
		try
		{
			string folderPath = ProjectStorage.RenameProjectFolder(selectedProject.FolderPath, newProjectName);
			selectedProject.Name = newProjectName;
			selectedProject.Course = newCourseName;
			selectedProject.FolderPath = folderPath;
			selectedProject.ModifiedAt = DateTimeOffset.Now;
			SaveProjects();
		}
		catch (Exception ex)
		{
			await ShowMessageAsync("Erro ao renomear projeto", "Não foi possível renomear a pasta do projeto escolar.\n\n" + ex.Message);
		}
	}

	private async void OnDeleteClicked(object sender, RoutedEventArgs e)
	{
		object selectedItem = ProjectsListView.SelectedItem;
		if (!(selectedItem is ProjectItem selectedProject) || await new ContentDialog
		{
			Title = "Confirmar exclusão",
			Content = "Deseja realmente excluir o projeto escolar \"" + selectedProject.Name + "\" e a pasta dele?",
			PrimaryButtonText = "Excluir",
			CloseButtonText = "Cancelar",
			DefaultButton = ContentDialogButton.Close,
			XamlRoot = base.XamlRoot
		}.ShowAsync() != ContentDialogResult.Primary)
		{
			return;
		}
		try
		{
			ProjectStorage.DeleteProjectFolder(selectedProject.FolderPath);
			Projects.Remove(selectedProject);
			SaveProjects();
			UpdateActionButtons();
		}
		catch (Exception ex)
		{
			await ShowMessageAsync("Erro ao excluir projeto", "Não foi possível excluir a pasta do projeto escolar.\n\n" + ex.Message);
		}
	}

	private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		UpdateActionButtons();
	}

	private async void OnProjectsListViewDoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
	{
		await TryOpenSelectedProjectAsync();
	}

	private async void OnProjectsListViewKeyDown(object sender, KeyRoutedEventArgs e)
	{
		if (e.Key == VirtualKey.Enter)
		{
			e.Handled = true;
			await TryOpenSelectedProjectAsync();
		}
	}

	private void UpdateActionButtons()
	{
		bool hasSelection = ProjectsListView.SelectedItem is ProjectItem;
		OpenButton.IsEnabled = hasSelection;
		RenameButton.IsEnabled = hasSelection;
		DeleteButton.IsEnabled = hasSelection;
	}

	private void LoadProjects()
	{
		bool shouldResave = false;
		foreach (ProjectItem project in ProjectRepository.LoadProjects())
		{
			string ensuredFolderPath = ProjectStorage.EnsureProjectFolder(project.Name, project.FolderPath);
			if (!string.Equals(project.FolderPath, ensuredFolderPath, StringComparison.OrdinalIgnoreCase))
			{
				project.FolderPath = ensuredFolderPath;
				shouldResave = true;
			}
			Projects.Add(project);
		}
		defaultProjectCounter = GetNextProjectCounter();
		if (shouldResave)
		{
			SaveProjects();
		}
	}

	private void SaveProjects()
	{
		ProjectRepository.SaveProjects(Projects);
	}

	private int GetNextProjectCounter()
	{
		int maxCounter = 0;
		foreach (ProjectItem project in Projects)
		{
			string suffix;
			if (project.Name.StartsWith("Instituição ", StringComparison.OrdinalIgnoreCase))
			{
				string name = project.Name;
				int length = "Instituição ".Length;
				suffix = name.Substring(length, name.Length - length).Trim();
			}
			else
			{
				if (!project.Name.StartsWith("Projeto ", StringComparison.OrdinalIgnoreCase))
				{
					continue;
				}
				string name = project.Name;
				int length = "Projeto ".Length;
				suffix = name.Substring(length, name.Length - length).Trim();
			}
			if (int.TryParse(suffix, out var counterValue))
			{
				maxCounter = Math.Max(maxCounter, counterValue);
			}
		}
		return maxCounter + 1;
	}

	private async Task TryOpenSelectedProjectAsync()
	{
		object selectedItem = ProjectsListView.SelectedItem;
		if (!(selectedItem is ProjectItem selectedProject))
		{
			return;
		}
		if (!Directory.Exists(selectedProject.FolderPath))
		{
			switch (await new ContentDialog
			{
				Title = "Pasta não encontrada",
				Content = "A pasta do projeto escolar \"" + selectedProject.Name + "\" não foi encontrada.\n\nDeseja recriar a pasta ou remover este projeto da lista?",
				PrimaryButtonText = "Recriar pasta",
				SecondaryButtonText = "Remover projeto",
				CloseButtonText = "Cancelar",
				DefaultButton = ContentDialogButton.Primary,
				XamlRoot = base.XamlRoot
			}.ShowAsync())
			{
			case ContentDialogResult.Primary:
				break;
			case ContentDialogResult.Secondary:
				Projects.Remove(selectedProject);
				SaveProjects();
				UpdateActionButtons();
				return;
			default:
				return;
			}
			try
			{
				selectedProject.FolderPath = ProjectStorage.EnsureProjectFolder(selectedProject.Name, selectedProject.FolderPath);
				selectedProject.ModifiedAt = DateTimeOffset.Now;
				SaveProjects();
			}
			catch (Exception ex)
			{
				await ShowMessageAsync("Erro ao recriar pasta", "Não foi possível recriar a pasta do projeto escolar.\n\n" + ex.Message);
				return;
			}
		}
		base.Frame?.Navigate(typeof(ProjectDetailsPage), selectedProject);
	}

	private async Task ShowMessageAsync(string title, string message)
	{
		await new ContentDialog
		{
			Title = title,
			Content = message,
			CloseButtonText = "Fechar",
			DefaultButton = ContentDialogButton.Close,
			XamlRoot = base.XamlRoot
		}.ShowAsync();
	}

	[GeneratedCode("Microsoft.UI.Xaml.Markup.Compiler", " 3.0.0.2602")]
	[DebuggerNonUserCode]
	public void InitializeComponent()
	{
		if (!_contentLoaded)
		{
			_contentLoaded = true;
			Uri resourceLocator = new Uri("ms-appx:///Views/MainPage.xaml");
			Application.LoadComponent(this, resourceLocator, ComponentResourceLocation.Application);
		}
	}

	[GeneratedCode("Microsoft.UI.Xaml.Markup.Compiler", " 3.0.0.2602")]
	[DebuggerNonUserCode]
	public void Connect(int connectionId, object target)
	{
		switch (connectionId)
		{
		case 2:
			ProjectsListView = target.As<ListView>();
			ProjectsListView.SelectionChanged += OnSelectionChanged;
			ProjectsListView.DoubleTapped += OnProjectsListViewDoubleTapped;
			ProjectsListView.KeyDown += OnProjectsListViewKeyDown;
			break;
		case 9:
			target.As<Button>().Click += OnCreateClicked;
			break;
		case 10:
			OpenButton = target.As<Button>();
			OpenButton.Click += OnOpenClicked;
			break;
		case 11:
			RenameButton = target.As<Button>();
			RenameButton.Click += OnRenameClicked;
			break;
		case 12:
			DeleteButton = target.As<Button>();
			DeleteButton.Click += OnDeleteClicked;
			break;
		}
		_contentLoaded = true;
	}

	[GeneratedCode("Microsoft.UI.Xaml.Markup.Compiler", " 3.0.0.2602")]
	[DebuggerNonUserCode]
	public IComponentConnector GetBindingConnector(int connectionId, object target)
	{
		IComponentConnector returnValue = null;
		if (connectionId == 4)
		{
			Grid element4 = (Grid)target;
			MainPage_obj4_Bindings bindings = new MainPage_obj4_Bindings();
			returnValue = bindings;
			bindings.SetDataRoot(element4.DataContext);
			element4.DataContextChanged += bindings.DataContextChangedHandler;
			DataTemplate.SetExtensionInstance(element4, bindings);
			XamlBindingHelper.SetDataTemplateComponent(element4, bindings);
		}
		return returnValue;
	}
}
