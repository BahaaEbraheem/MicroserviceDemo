import { ModuleWithProviders, NgModule } from '@angular/core';
import { AML_MANAGEMENT_ROUTE_PROVIDERS } from './providers/route.provider';

@NgModule()
export class AmlManagementConfigModule {
  static forRoot(): ModuleWithProviders<AmlManagementConfigModule> {
    return {
      ngModule: AmlManagementConfigModule,
      providers: [AML_MANAGEMENT_ROUTE_PROVIDERS],
    };
  }
}
