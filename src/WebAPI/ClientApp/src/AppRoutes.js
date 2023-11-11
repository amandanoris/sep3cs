/* Copyright (c) 2023-2025
 * This file is part of sep3cs.
 *
 * sep3cs is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * sep3cs is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with sep3cs. If not, see <http://www.gnu.org/licenses/>.
 */
import { Home } from './components/Home'
import { Login } from './components/Login'
import { Route, Routes } from 'react-router-dom'
import { RequireAuth } from 'react-auth-kit'

const AppRoutes = () => (
    <Routes>
      <Route path={'/'} element={<Home />} index={true} />
      <Route path={'/login'} element={<Login />} />
      <Route path={'/dashboard'} element={<RequireAuth><p>Dashboard</p></RequireAuth>}/>
    </Routes>
)

export default AppRoutes;
