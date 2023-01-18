using AmlManagement.Aml_Person;
using CurrencyManagment.Currencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Volo.Abp.Uow;
using Volo.Abp.Users;

namespace AmlManagment;
public class AmlManagmentDataSeederContributor
      : IDataSeedContributor, ITransientDependency
{
    private readonly IGuidGenerator _guidGenerator;
    private readonly IAmlPersonRepository _amlPersonRepository;
    private readonly ICurrentUser _currentUser;


    public AmlManagmentDataSeederContributor(

        IGuidGenerator guidGenerator,

        IAmlPersonRepository amlPersonRepository,
        ICurrentUser currentUser
    )
    {
        _guidGenerator = guidGenerator;
        _amlPersonRepository = amlPersonRepository;
        _currentUser = currentUser;
    }
    [UnitOfWork]
    public virtual async Task SeedAsync(DataSeedContext context)
    {
        await SeedAmlPersonAsync();
     

    }

    // private async Task SeedRolesAsync()
    // {

    //     if (await _roleRepository.GetCountAsync() > 1)
    //     {
    //         return;
    //     }
    //     await _roleRepository.InsertAsync(
    //        new IdentityRole
    //        (
    //          _guidGenerator.Create(),
    //           "Creator"
    //        ),
    //        autoSave: true
    //    );
    //     await _roleRepository.InsertAsync(
    //        new IdentityRole
    //        (
    //          _guidGenerator.Create(),
    //           "Supervisor"
    //        ),
    //        autoSave: true
    //    );
    //     await _roleRepository.InsertAsync(
    //    new IdentityRole
    //    (
    //      _guidGenerator.Create(),
    //       "Releaser"
    //    ),
    //    autoSave: true
    //);

    // }

    private async Task SeedAmlPersonAsync()
    {
        if (await _amlPersonRepository.GetCountAsync() > 0)
        {
            return;
        }


        await _amlPersonRepository.InsertAsync(
            new AmlPerson
            (
              _guidGenerator.Create(),
               "Bahaa",
                "Ebraheem",
               "Abd",
               "Evvet"

            ),
            autoSave: true
        );


        await _amlPersonRepository.InsertAsync(

        new AmlPerson
            (
              _guidGenerator.Create(),
               "Ali",
                "Ahmad",
               "saaaed",
               "lama"

            ),
            autoSave: true
        );

        await _amlPersonRepository.InsertAsync(
      new AmlPerson
            (
              _guidGenerator.Create(),
               "Khaled",
                "Ebraheem",
               "ali",
               "hend"

            ),
            autoSave: true
        );

        await _amlPersonRepository.InsertAsync(
        new AmlPerson
            (
              _guidGenerator.Create(),
               "Omar",
                "abd Alrahman",
               "Khaled",
               "Khadiga"

            ),
            autoSave: true

       );

    }
}

