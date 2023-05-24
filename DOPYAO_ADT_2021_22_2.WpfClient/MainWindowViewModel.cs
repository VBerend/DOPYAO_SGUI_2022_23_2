using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DOPYAO_ADT_2021_22_2.Models;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
namespace DOPYAO_ADT_2021_22_2.WpfClient
{
	public class MainWindowViewModel : ObservableRecipient
	{
		public RestCollection<Adopter> Adopters { get; set; }
		public RestCollection<Shelter> Shelters { get; set; }
		public RestCollection<Animal> Animals { get; set; }

		public RestService RestService { get; set; }

		private Adopter chosenAdopter;
		private Shelter chosenShelter;
		private Animal chosenAnimal;

		public ICommand CreateAdopterCommand { get; set; }
		public ICommand UpdateAdopterCommand { get; set; }
		public ICommand DeleteAdopterCommand { get; set; }

		public ICommand CreateShelterCommand { get; set; }
		public ICommand UpdateShelterCommand { get; set; }
		public ICommand DeleteShelterCommand { get; set; }

		public ICommand CreateAnimalCommand { get; set; }
		public ICommand UpdateAnimalCommand { get; set; }
		public ICommand DeleteAnimalCommand { get; set; }


		public Adopter ChosenAdopter
		{
			get { return chosenAdopter; }
			set
			{
				if (value != null)
				{
					chosenAdopter = new Adopter()
					{
						Name = value.Name,
						Address = value.Address,
						Animals = value.Animals,
						City = value.City,
						HasKid = value.HasKid,
						Id = value.Id,

					};

					OnPropertyChanged();
					(DeleteAdopterCommand as RelayCommand).NotifyCanExecuteChanged();
				}
			}
		}

		public Shelter ChosenShelter
		{
			get { return chosenShelter; }
			set
			{
				if (value != null)
				{
					chosenShelter = new Shelter()
					{
						Animals = value.Animals,
						Address = value.Address,
						City = value.City,
						Id = value.Id,
						ShelterName = value.ShelterName,
					};

					OnPropertyChanged();
					(DeleteShelterCommand as RelayCommand).NotifyCanExecuteChanged();
				}
			}
		}

		public Animal ChosenAnimal
		{
			get { return chosenAnimal; }
			set
			{
				if (value != null)
				{
					chosenAnimal = new Animal()
					{
						Adopter = value.Adopter,
						AdopterId = value.AdopterId,
						Age = value.Age,
						Bodysize = value.Bodysize,
						Gender = value.Gender,
						Id = value.Id,
						Name = value.Name,
						Shelter = value.Shelter,
						ShelterId = value.ShelterId,
						Specie = value.Specie,
					};

					OnPropertyChanged();
					(DeleteAnimalCommand as RelayCommand).NotifyCanExecuteChanged();
				}
			}
		}
		public static bool IsInDesignMode
		{
			get
			{
				var prop = DesignerProperties.IsInDesignModeProperty;
				return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
			}
		}

		public MainWindowViewModel()
		{
			if (!IsInDesignMode)
			{
				Adopters = new RestCollection<Adopter>("http://localhost:38088/", "Adopter");
				Shelters = new RestCollection<Shelter>("http://localhost:38088/", "Shelter");
				Animals = new RestCollection<Animal>("http://localhost:38088/", "Animal");

				RestService = new("http://localhost:38088/");


				CreateAdopterCommand = new RelayCommand(() =>
				{
					Adopters.Add(new Adopter()
					{
						Name = ChosenAdopter.Name,
						Address = ChosenAdopter.Address,
						Animals = ChosenAdopter.Animals,
						City = ChosenAdopter.City,
						HasKid = ChosenAdopter.HasKid,
						Id = ChosenAdopter.Id,
					});

				});

				UpdateAdopterCommand = new RelayCommand(() =>
				{
					Adopters.Update(ChosenAdopter);
				});
				ChosenAdopter = new Adopter();


				DeleteAdopterCommand = new RelayCommand(() =>
				{
					Adopters.Delete(ChosenAdopter.Id);
				},
				() =>
				{
					return ChosenAdopter != null;
				});

				CreateShelterCommand = new RelayCommand(() =>
				{
					Shelters.Add(new Shelter()
					{
						Address = ChosenShelter.Address,
						Animals = ChosenShelter.Animals,
						City = ChosenShelter.City,
						Id = ChosenShelter.Id,
						ShelterName = ChosenShelter.ShelterName
					});
				});

				UpdateShelterCommand = new RelayCommand(() =>
				{
					Shelters.Update(ChosenShelter);
				});
				ChosenShelter = new Shelter();


				DeleteShelterCommand = new RelayCommand(() =>
				{
					Shelters.Delete(ChosenShelter.Id);
				},
				() =>
				{
					return ChosenShelter != null;
				});

				CreateAnimalCommand = new RelayCommand(() =>
				{
					Animals.Add(new Animal()
					{
						Adopter = ChosenAnimal.Adopter,
						AdopterId = ChosenAnimal.AdopterId,
						Age = ChosenAnimal.Age,
						Bodysize = ChosenAnimal.Bodysize,
						Gender = ChosenAnimal.Gender,
						Id = ChosenAnimal.Id,
						Name = ChosenAnimal.Name,
						Shelter = ChosenAnimal.Shelter,
						ShelterId = ChosenAnimal.Id,
						Specie = ChosenAnimal.Specie
					});
				});

				UpdateAnimalCommand = new RelayCommand(() =>
				{
					Animals.Update(ChosenAnimal);
				});
				ChosenAnimal = new Animal();


				DeleteAnimalCommand = new RelayCommand(() =>
				{
					Animals.Delete(ChosenAnimal.Id);
				},
				() =>
				{
					return ChosenAnimal != null;
				});
			}
		}
	}
}
