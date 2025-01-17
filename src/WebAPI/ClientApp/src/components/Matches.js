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
import { Button, Table,Input, Label } from 'reactstrap'
import { CreateMatchCommand } from '../webApiClient.ts'
import { DateTime } from './DateTime'
import { Pager } from './Pager'
import { TimeSpan } from './TimeSpan'
import { UpdateMatchCommand } from '../webApiClient.ts'
import { useAuthorize } from '../services/AuthorizeProvider'
import { useErrorReporter } from './ErrorReporter'
import { useParams } from 'react-router-dom'
import { UserRoles } from '../services/AuthorizeConstants'
import { WaitSpinner } from './WaitSpinner'
import { MatchClient } from '../webApiClient.ts'
import React, { useEffect, useState } from 'react'


export function Matches ()
{
  const { initialPage } = useParams ()
  const [ activePage, setActivePage ] = useState (initialPage ? initialPage : 0)
  const [ hasNextPage, setHasNextPage ] = useState (false)
  const [ hasPreviousPage, setHasPreviousPage ] = useState (false)
  const { isAuthorized, inRole }= useAuthorize ()
  const [ isLoading, setIsLoading ] = useState (false)
  const [ items, setItems ] = useState (undefined)
  const [ totalPages, setTotalPages ] = useState (0)
  const [ matchClient ] = useState (new MatchClient ())
  const errorReporter = useErrorReporter ()

  

  const pageSize = 10
  const visibleIndices = 5
  var mydate = new Date()
  var winner = 1
  var looser = 2
  var dur = "00:00:01"
  function SetWinner(val)
  {
    winner = val
  }
  function SetLooser(val)
  {
    looser = val
  }
  function SetDate(val) 
  { 
    mydate = val  
  }
  function SetDuration(val) 
  { 
    dur = val  
  }
  const addMatch = async () =>
    {
      const data = new CreateMatchCommand ()
      data.winnerPlayerId = winner
      data.looserPlayerId = looser
      data.beginDate = mydate
      data.duration = dur
      try
      {
        await matchClient.create (data)
        setActivePage (-1)
      }
      catch(error)
      {
        errorReporter(error)
      }
      
    }

  const removeMatch = async (item) =>
    {
      try
      {
        await matchClient.delete (item.looserPlayerId,item.winnerPlayerId, item.beginDate )
        setActivePage (-1)
      }
      catch(error)
      {
        errorReporter(error)
      }
    }

  const updateMatch = async (item) =>
    {
      const data = new UpdateMatchCommand ()
      data.winnerPlayerId = item.winnerPlayerId
      data.looserPlayerId = item.looserPlayerId
      data.beginDate = item.beginDate
      data.duration = item.duration
      try
      {
        await matchClient.update (item.looserPlayerId,item.winnerPlayerId, item.beginDate, data)
      }
      catch(error)
      {
        errorReporter(error)
      }
    }

  useEffect (() =>
    {
      const lastPage = async () =>
        {
          try
          {
            const paginatedList = await matchClient.getWithPagination (1, pageSize)
            return paginatedList.totalPages
          }
          catch(error)
          {
            errorReporter(error)
            return 0
          }
          
        }

      const refreshPage = async () =>
        {
          try
          {
            const paginatedList = await matchClient.getWithPagination (activePage + 1, pageSize)

            setHasNextPage (paginatedList.hasNextPage)
            setHasPreviousPage (paginatedList.hasPreviousPage)
            setItems (paginatedList.items)
            setTotalPages (paginatedList.totalPages)
          }
          catch(error)
          {
            errorReporter(error)
          }
        }

      if (activePage >= 0)
        {
          setIsLoading (true)
          refreshPage ().then (() => setIsLoading (false))
        }
      else
        {
          lastPage ().then ((total) =>
            {
              if (total === 0)
                setActivePage (0)
              else
                setActivePage (total - 1)
            })
        }
    // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [activePage])

  return (
    isLoading || !isAuthorized
      ? (<WaitSpinner/>)
    : (
      <>
        
        <div className='d-flex justify-content-center'>
          <Pager
            activePage={activePage}
            hasNextPage={hasNextPage}
            hasPreviousPage={hasPreviousPage}
            onPageChanged={(index) => setActivePage (index)}
            totalPages={totalPages}
            visibleIndices={visibleIndices} />
        </div>
        
        <div>
        <h1>Matches</h1>
          <Table border='1'>
            <thead>
              <tr>
                <th>{'Winner player'}</th>
                <th>{'Looser player'}</th>
                <th>{'Begin date'}</th>
                <th>{'Duration'}</th>
                <th />
              </tr>
            </thead>
            <tbody>
        { (items ?? []).map ((item, index) => (
              <tr key={`body${index}`}>
                <td>
                  <p>{ item.winnerPlayerId }</p>
                </td>
                <td>
                  <p>{ item.looserPlayerId }</p>
                </td>
                <td>
                  <DateTime
                    defaultValue={item.beginDate}
                    readOnly={true} />
                </td>
                <td>
                  <TimeSpan
                    defaultValue={item.duration}
                    onChanged={(span) => { item.duration = span; updateMatch (item) }}
                    readOnly={!inRole[UserRoles.Administrator]} />
                </td>
        {
          (!inRole[UserRoles.Administrator])
          ? (<td />)
          : (
                <td>
                  <Button color='primary' onClick={() => removeMatch (item)} close />
                </td>)
        }
              </tr>))
        }
            </tbody>
            <tfoot>
        {
          (!inRole[UserRoles.Administrator])
          ? (<tr />)
          : (
              <tr key='footer0' striped bordered dark color = 'blue'>
                
                
                <td>
                  <Input
                    type='number'
                    onChange={(e) => SetWinner (e.target.value)}/>
                </td>
                <td>
                  <Input
                    type='number'
                    onChange={(e) => SetLooser (e.target.value)}/>
                </td>
                
                <td>
                <DateTime
                    defaultValue={new Date()}
                    onChanged={(date) => { SetDate(date) }}
                    readOnly={!inRole[UserRoles.Administrator]} />
                </td>

                <TimeSpan
                    defaultValue='00:00:01'
                    onChanged={(span) => { SetDuration (span) }}
                    readOnly={!inRole[UserRoles.Administrator]} />
                <td>
                  <Button color='primary' onClick={() => addMatch ()}>+</Button>
                </td>
                
              </tr>
              )
        }
         </tfoot>
            
           
          </Table>
        </div>
      </>))
}
