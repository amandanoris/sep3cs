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
import { Alert } from 'reactstrap'
import { WaitSpinner } from '../WaitSpinner'
import React, { useState } from 'react'
import { ProfilePage } from './ProfilePage'

export function ProfileDeck (props)
{
  const { playerProfile } = props
  const [ isLoading, setIsLoading ] = useState (false)

  if (!playerProfile)
    return (<Alert color='warning'>User has not player status</Alert>)
  else
    return (
      isLoading
      ? <WaitSpinner />
      : <ProfilePage title='Deck'>
          <p>Player cards placeholder</p>
        </ProfilePage>)
}
