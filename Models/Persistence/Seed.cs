using JuanBosch.App.Models.Address;
using JuanBosch.App.Models.Ars;
using JuanBosch.App.Models.Bloods;
using JuanBosch.App.Models.Dates;
using JuanBosch.App.Models.Doctors;
using JuanBosch.App.Models.MedicRecords;
using JuanBosch.App.Models.Patients;
using JuanBosch.App.Models.PatientsDoctors;
using JuanBosch.App.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuanBosch.App.Models.Persistence
{
    public class Seed
    {
        public static async Task SeedUsers(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            try
            {
                Console.WriteLine("Starting user seeding process...");
                
                // Always ensure roles exist
                var requiredRoles = new[] { "Administrador", "usuario", "auxiliar" };
                foreach (var roleName in requiredRoles)
                {
                    if (!await roleManager.RoleExistsAsync(roleName))
                    {
                        var role = new ApplicationRole(roleName);
                        var roleResult = await roleManager.CreateAsync(role);
                        if (roleResult.Succeeded)
                        {
                            Console.WriteLine($"Created role: {roleName}");
                        }
                        else
                        {
                            Console.WriteLine($"Failed to create role {roleName}: {string.Join(", ", roleResult.Errors.Select(e => e.Description))}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Role already exists: {roleName}");
                    }
                }

                // Always ensure admin user exists
                var adminUser = await userManager.FindByNameAsync("admin");
                if (adminUser == null)
                {
                    Console.WriteLine("Admin user not found. Creating admin user...");
                    adminUser = new ApplicationUser
                    {
                        UserName = "admin",
                        Email = "admin@juanbosch.com",
                        FirstName = "Admin",
                        LastName = "User",
                        EmailConfirmed = true
                    };

                    var result = await userManager.CreateAsync(adminUser, "123456789wW#");
                    if (result.Succeeded)
                    {
                        Console.WriteLine("Admin user created successfully");
                        
                        // Ensure admin has the Administrador role
                        if (!await userManager.IsInRoleAsync(adminUser, "Administrador"))
                        {
                            var roleResult = await userManager.AddToRoleAsync(adminUser, "Administrador");
                            if (roleResult.Succeeded)
                            {
                                Console.WriteLine("Admin user added to Administrador role");
                            }
                            else
                            {
                                Console.WriteLine($"Failed to add admin to role: {string.Join(", ", roleResult.Errors.Select(e => e.Description))}");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Failed to create admin user: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                    }
                }
                else
                {
                    Console.WriteLine("Admin user already exists");
                    
                    // Ensure existing admin has the Administrador role
                    if (!await userManager.IsInRoleAsync(adminUser, "Administrador"))
                    {
                        var roleResult = await userManager.AddToRoleAsync(adminUser, "Administrador");
                        if (roleResult.Succeeded)
                        {
                            Console.WriteLine("Added Administrador role to existing admin user");
                        }
                        else
                        {
                            Console.WriteLine($"Failed to add role to existing admin: {string.Join(", ", roleResult.Errors.Select(e => e.Description))}");
                        }
                    }
                }
                
                Console.WriteLine("User seeding process completed");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during user seeding: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
                throw; // Re-throw to be handled by the calling code
            }
        }

        public static async Task SeedData(DataContext context)
        {
            try
            {
                Console.WriteLine("Starting data seeding process...");

                await SeedAddressData(context);
                await SeedBloodData(context);
                await SeedArsData(context);
                await SeedDoctorData(context);
                await SeedPatientData(context);

                Console.WriteLine("Data seeding completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during data seeding: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
                throw;
            }
        }

        private static async Task SeedAddressData(DataContext context)
        {
            if (await context.Countries.AnyAsync())
            {
                Console.WriteLine("Address data already exists. Skipping address seeding.");
                return;
            }

            var country = new Country
            {
                CountryName = "República Dominicana",
                CountryLanguage = "Español",
                CountryCurrency = "DOP"
            };
            context.Countries.Add(country);
            await context.SaveChangesAsync();

            var provinces = new List<Province>
            {
                new Province { ProvinceName = "Santo Domingo", CountryId = country.CountryId },
                new Province { ProvinceName = "Santiago", CountryId = country.CountryId },
                new Province { ProvinceName = "La Romana", CountryId = country.CountryId }
            };
            context.Provinces.AddRange(provinces);
            await context.SaveChangesAsync();

            var municipalities = new List<Municipality>
            {
                new Municipality { MunicipalityName = "Santo Domingo Norte", ProvinceId = provinces[0].ProvinceId },
                new Municipality { MunicipalityName = "Santo Domingo Oeste", ProvinceId = provinces[0].ProvinceId },
                new Municipality { MunicipalityName = "Santiago de los Caballeros", ProvinceId = provinces[1].ProvinceId },
                new Municipality { MunicipalityName = "La Romana", ProvinceId = provinces[2].ProvinceId }
            };
            context.Municipalities.AddRange(municipalities);
            await context.SaveChangesAsync();

            var sectors = new List<Sector>
            {
                new Sector { SectorName = "Naco", MunicipalityId = municipalities[0].MunicipalityId },
                new Sector { SectorName = "Gazcue", MunicipalityId = municipalities[1].MunicipalityId },
                new Sector { SectorName = "Los Jardines", MunicipalityId = municipalities[2].MunicipalityId },
                new Sector { SectorName = "Callejón", MunicipalityId = municipalities[3].MunicipalityId }
            };
            context.Sectors.AddRange(sectors);
            await context.SaveChangesAsync();

            Console.WriteLine("Address data seeded successfully.");
        }

        private static async Task SeedBloodData(DataContext context)
        {
            if (await context.Bloods.AnyAsync())
            {
                Console.WriteLine("Blood data already exists. Skipping blood seeding.");
                return;
            }

            var bloods = new List<Blood>
            {
                new Blood { BloodType = "A+", ConsentBlood = true },
                new Blood { BloodType = "A-", ConsentBlood = true },
                new Blood { BloodType = "B+", ConsentBlood = true },
                new Blood { BloodType = "B-", ConsentBlood = true },
                new Blood { BloodType = "AB+", ConsentBlood = true },
                new Blood { BloodType = "AB-", ConsentBlood = true },
                new Blood { BloodType = "O+", ConsentBlood = true },
                new Blood { BloodType = "O-", ConsentBlood = true }
            };
            context.Bloods.AddRange(bloods);
            await context.SaveChangesAsync();

            Console.WriteLine("Blood data seeded successfully.");
        }

        private static async Task SeedArsData(DataContext context)
        {
            if (await context.ArsEnsurances.AnyAsync())
            {
                Console.WriteLine("ARS data already exists. Skipping ARS seeding.");
                return;
            }

            var arsList = new List<ArsEnsurance>
            {
                new ArsEnsurance
                {
                    EnsuranceName = "SENASA",
                    EnsuranceDirection = "Av. Winston Churchill, Santo Domingo",
                    EnsurancePhone = "809-732-1234",
                    EnsuranceEmail = "contacto@senasa.gob.do",
                    EnsuranceUpdateDate = DateTime.UtcNow,
                    EnsuranceSchedule = new TimeOnly(8, 0)
                },
                new ArsEnsurance
                {
                    EnsuranceName = "HUMANO",
                    EnsuranceDirection = "Av. Abraham Lincoln, Santo Domingo",
                    EnsurancePhone = "809-620-1234",
                    EnsuranceEmail = "servicios@humano.com.do",
                    EnsuranceUpdateDate = DateTime.UtcNow,
                    EnsuranceSchedule = new TimeOnly(8, 0)
                },
                new ArsEnsurance
                {
                    EnsuranceName = "SEMA",
                    EnsuranceDirection = "Av. Independencia, Santo Domingo",
                    EnsurancePhone = "809-541-1234",
                    EnsuranceEmail = "info@sema.com.do",
                    EnsuranceUpdateDate = DateTime.UtcNow,
                    EnsuranceSchedule = new TimeOnly(8, 0)
                }
            };
            context.ArsEnsurances.AddRange(arsList);
            await context.SaveChangesAsync();

            var plans = new List<ArsPlans>
            {
                new ArsPlans
                {
                    AfiliationNumberArs = "SEN-001",
                    ArsPlansName = "Plan Básico",
                    CoveragePlanArs = "80%",
                    InternationalCoverage = false,
                    IsPlanActive = true,
                    MaxLimitArs = "RD$ 500,000",
                    ArsEnsuranceId = arsList[0].ArsEnsuranceId
                },
                new ArsPlans
                {
                    AfiliationNumberArs = "HUM-001",
                    ArsPlansName = "Plan Premium",
                    CoveragePlanArs = "90%",
                    InternationalCoverage = true,
                    IsPlanActive = true,
                    MaxLimitArs = "RD$ 2,000,000",
                    ArsEnsuranceId = arsList[1].ArsEnsuranceId
                },
                new ArsPlans
                {
                    AfiliationNumberArs = "SEM-001",
                    ArsPlansName = "Plan Familiar",
                    CoveragePlanArs = "85%",
                    InternationalCoverage = false,
                    IsPlanActive = true,
                    MaxLimitArs = "RD$ 1,000,000",
                    ArsEnsuranceId = arsList[2].ArsEnsuranceId
                }
            };
            context.ArsPlans.AddRange(plans);
            await context.SaveChangesAsync();

            Console.WriteLine("ARS data seeded successfully.");
        }

        private static async Task SeedDoctorData(DataContext context)
        {
            if (await context.Doctors.AnyAsync())
            {
                Console.WriteLine("Doctor data already exists. Skipping doctor seeding.");
                return;
            }

            var sector = await context.Sectors.FirstOrDefaultAsync();
            if (sector == null)
            {
                Console.WriteLine("No sectors found. Skipping doctor seeding.");
                return;
            }

            var doctorAddresses = new List<DoctorAddress>
            {
                new DoctorAddress { DoctorHouseNumber = "123", DoctorStreet = "Calle Principal", SectorId = sector.SectorId, Sector = sector },
                new DoctorAddress { DoctorHouseNumber = "456", DoctorStreet = "Av. Central", SectorId = sector.SectorId, Sector = sector }
            };
            context.DoctorAddresses.AddRange(doctorAddresses);
            await context.SaveChangesAsync();

            var doctors = new List<DoctorMedic>
            {
                new DoctorMedic
                {
                    DoctorName = "Carlos",
                    DoctorLastName = "García",
                    DoctorPhone = "809-123-4567",
                    DoctorEmail = "cgarcia@hospital.com",
                    DoctorIdCard = "001-1234567-1",
                    DoctorPassport = "RD001",
                    DoctorSpeciality = "Medicina General",
                    DoctorAddressId = doctorAddresses[0].DoctorAddressId,
                    DoctorExecatur = "12345"
                },
                new DoctorMedic
                {
                    DoctorName = "María",
                    DoctorLastName = "López",
                    DoctorPhone = "809-987-6543",
                    DoctorEmail = "mlopez@hospital.com",
                    DoctorIdCard = "001-7654321-0",
                    DoctorPassport = "RD002",
                    DoctorSpeciality = "Cardiología",
                    DoctorAddressId = doctorAddresses[1].DoctorAddressId,
                    DoctorExecatur = "67890"
                }
            };
            context.Doctors.AddRange(doctors);
            await context.SaveChangesAsync();

            Console.WriteLine("Doctor data seeded successfully.");
        }

        private static async Task SeedPatientData(DataContext context)
        {
            if (await context.Patients.AnyAsync())
            {
                Console.WriteLine("Patient data already exists. Skipping patient seeding.");
                return;
            }

            var arsPlan = await context.ArsPlans.FirstOrDefaultAsync();
            var blood = await context.Bloods.FirstOrDefaultAsync();
            var sector = await context.Sectors.FirstOrDefaultAsync();
            var doctor = await context.Doctors.FirstOrDefaultAsync();

            if (arsPlan == null || blood == null || sector == null || doctor == null)
            {
                Console.WriteLine("Missing required reference data. Skipping patient seeding.");
                return;
            }

            var patientDirections = new List<PatientDirection>
            {
                new PatientDirection { HouseNumber = "10", HouseStreet = "Calle A", SectorId = sector.SectorId },
                new PatientDirection { HouseNumber = "20", HouseStreet = "Calle B", SectorId = sector.SectorId }
            };
            context.PatientDirections.AddRange(patientDirections);
            await context.SaveChangesAsync();

            var patients = new List<Patient>
            {
                new Patient
                {
                    PatientName = "Juan",
                    PatientLastName = "Pérez",
                    PatientIdCard = "001-2345678-9",
                    PatientPassport = "RD123",
                    PatientBirthDate = new DateOnly(1985, 5, 15),
                    PatientGender = "Masculino",
                    PatientEmail = "jperez@email.com",
                    PatientPhone = "809-555-1111",
                    ArsPlansId = arsPlan.ArsPlansId,
                    AddressId = patientDirections[0].AddressId,
                    PatientEmergencieContact = "Ana Pérez - 809-555-2222",
                    PatientFisRecord = "FIS-001",
                    BloodId = blood.BloodId
                },
                new Patient
                {
                    PatientName = "Ana",
                    PatientLastName = "Martínez",
                    PatientIdCard = "001-9876543-2",
                    PatientPassport = "RD456",
                    PatientBirthDate = new DateOnly(1990, 8, 22),
                    PatientGender = "Femenino",
                    PatientEmail = "amartinez@email.com",
                    PatientPhone = "809-555-3333",
                    ArsPlansId = arsPlan.ArsPlansId,
                    AddressId = patientDirections[1].AddressId,
                    PatientEmergencieContact = "Luis Martínez - 809-555-4444",
                    PatientFisRecord = "FIS-002",
                    BloodId = blood.BloodId
                }
            };
            context.Patients.AddRange(patients);
            await context.SaveChangesAsync();

            var medicRecords = new List<MedicRecord>
            {
                new MedicRecord
                {
                    Patient = patients[0],
                    DoctorId = doctor.DoctorId,
                    FollowUpMedicRecord = "Control anual de presión arterial.",
                    SignsMedicRecord = "Presión arterial normal."
                },
                new MedicRecord
                {
                    Patient = patients[1],
                    DoctorId = doctor.DoctorId,
                    FollowUpMedicRecord = "Seguimiento de alergias estacionales.",
                    SignsMedicRecord = "Sin signos de alerta."
                }
            };
            context.MedicRecords.AddRange(medicRecords);
            await context.SaveChangesAsync();

            var patientDoctors = new List<PatientsDoctor>
            {
                new PatientsDoctor { PatientId = patients[0].PatientId, DoctorId = doctor.DoctorId },
                new PatientsDoctor { PatientId = patients[1].PatientId, DoctorId = doctor.DoctorId }
            };
            context.Set<PatientsDoctor>().AddRange(patientDoctors);
            await context.SaveChangesAsync();

            Console.WriteLine("Patient data seeded successfully.");
        }
    }
}
