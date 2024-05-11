
import { Controller, Post, Body, Get, Param, Put, Patch, Delete } from '@nestjs/common';

@Controller('users')// /users
export class UserController {

  @Post('postUser')
  async postUser(@Body() body) {
    return {body};
  }

  @Get('getAllUsers')
  async getAllUsers() {
    return {users: []}
  }

  @Get('getUser/:id')
  async getUser(@Param() param) {
    return {user: {}, param}
  }

  @Put('putUser/:id')
  async putUser(@Body() body, @Param() id) {
    return { body, id }
  }

  @Patch('patchUser/:id')
  async patchUser(@Body() body, @Param() id) {
    return { body, id }
  }

  @Delete('deleteUser/:id')
  async deleteUser(@Param() id) {
    return { id }
  }
}