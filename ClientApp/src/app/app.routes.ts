import { Routes } from '@angular/router';
import { NoAuthGuard } from './core/auth/guards/no-auth.guard';
import { AuthGuard } from './core/auth/guards/auth.guard';
import { PageNotFoundComponent } from './shared/components/page-not-found/page-not-found.component';
import { LoginComponent } from './core/auth/pages/login/loign.component';
export const routes: Routes = [
    {
        path: '',
        redirectTo: "dashboard",
        pathMatch: 'full'
    },
    {
        path: 'login',
        canActivate: [NoAuthGuard],
        canActivateChild: [NoAuthGuard],
        data: { title: 'Login - Project Management' },
        component: LoginComponent,
    },
    {
        path: 'dashboard',
        canActivate: [AuthGuard],
        canActivateChild: [AuthGuard],
        loadComponent: () =>
            import('../app/layouts/components/layout/layout.component').then((m) => m.LayoutComponent),
        children: [
            {
                path: '',
                loadComponent: () =>
                    import('../app/features/dashboard/dashboard.component').then((m) => m.DashboardComponent),
            },
        ],
    },
    {
        path: '**', // handle undefined paths
        component: PageNotFoundComponent
    }
];
