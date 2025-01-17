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
import { Input, InputGroup } from 'reactstrap'
import React, { useEffect, useRef, useState } from 'react'

// TODO: make this better

export function TimeSpan (props)
{
  const { defaultValue, readOnly, onChanged } = props
  const [ span, setSpan ] = useState (defaultValue)
  const firstRender = useRef (true)

  const update = (value) =>
    {
      setSpan (value)
    }

  useEffect (() =>
    {
      if (firstRender.current)
        firstRender.current = false
      else
        {
          onChanged (span)
        }
    // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [span])

  if (!readOnly)
    return (
      <InputGroup className='d-flex'>
        <Input type='text' className='flex-grow-1 flex-shrink-1 p-2'
          defaultValue={defaultValue} onChange={(e) => update (e.target.value)} />
      </InputGroup>)
  else
    return (
      <InputGroup className='d-flex'>
        <Input type='text' className='flex-grow-1 flex-shrink-1 p-2'
          defaultValue={defaultValue} disabled onChange={(e) => e.preventDefault ()} />
      </InputGroup>)
}
