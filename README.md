# Api_Projeto_C-

GETBYID {var servidor = await _context.Servidores.Where(servidor => servidor.id == id).FirstOrDefaultAsync();
}
post{
 await _context.Servidores.AddAsync(servidor);
 await _context.SaveChangesAsync();
   return Created("",servidor);
 }

 update{
      var servidor = await _context.Servidores.FindAsync(id);
            _context.Servidores.Update(servidor);
         await _context.SaveChangesAsync();
 }

 delete{   var servidor = await _context.Servidores.FindAsync(id);
   if (servidor == null) {
       NotFound("Servidor não encontrado");
   }

   _context.Servidores.Remove(servidor);
   await _context.SaveChangesAsync();}