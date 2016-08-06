package app.controllers;

import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;

import javax.servlet.http.HttpSession;
import java.util.ArrayList;
import java.util.List;

@Controller
public class DeleteController {
    @RequestMapping("/delete/{id}")
    public String delete(HttpSession httpSession, @PathVariable(value = "id") int item) {
        List<String> items = (ArrayList<String>) httpSession.getAttribute("list");
        items.remove(item);

        httpSession.setAttribute("list", items);

        return "redirect:/index";
    }
}
