import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { AmlManagementComponent } from './components/aml-management.component';
import { AmlManagementRoutingModule } from './aml-management-routing.module';

@NgModule({
  declarations: [AmlManagementComponent],
  imports: [CoreModule, ThemeSharedModule, AmlManagementRoutingModule],
  exports: [AmlManagementComponent],
})
export class AmlManagementModule {
  static forChild(): ModuleWithProviders<AmlManagementModule> {
    return {
      ngModule: AmlManagementModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<AmlManagementModule> {
    return new LazyModuleFactory(AmlManagementModule.forChild());
  }
}
